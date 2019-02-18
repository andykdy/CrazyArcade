using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestructor : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wallTile;
    public Tile destructibleTile;

    public GameObject explosionPrefab;
    public GameObject speedPrefab;
    public GameObject powerPrefab;
    public GameObject bombCountPrefab;

    public void Explode(Vector2 worldPos, float explosionPower){
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
        for (int i = 0; i < explosionPower; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(i + 1, 0, 0)))
            {
                break;
            }
        }
        for (int i = 0; i < explosionPower; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(-i - 1, 0, 0)))
            {
                break;
            }
        }
        for (int i = 0; i < explosionPower; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(0, i + 1, 0)))
            {
                break;
            }
        }
        for (int i = 0; i < explosionPower; i++)
        {
            if (!ExplodeCell(originCell + new Vector3Int(0, -i - 1, 0)))
            {
                break;
            }
        }
    }

    bool ExplodeCell(Vector3Int cell){
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == wallTile)
        {
            return false;
        }
        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        if (tile == destructibleTile)
        {
            tilemap.SetTile(cell, null);
            if (Random.Range(0.0f, 100.0f) > 50.0f)
            {
                float item_randomizer = Random.Range(0.0f, 100.0f);
                if (item_randomizer > 66.6f)
                {
                    Instantiate(powerPrefab, pos, Quaternion.identity);
                } else if(33.3f <= item_randomizer)
                {
                    Instantiate(speedPrefab, pos, Quaternion.identity);
                }
                else
                {
                    Instantiate(bombCountPrefab, pos, Quaternion.identity);
                }
            }
            return false;
        }
        Instantiate(explosionPrefab, pos, Quaternion.identity);
        return true;
    }

}

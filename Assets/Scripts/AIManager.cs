using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AIManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject nodePrefab;
    private GameObject[,] mapNodes;

    private void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        mapNodes = new GameObject[bounds.size.x, bounds.size.y];
        
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile.name == "Crate")
                {
                    GameObject node = Instantiate(nodePrefab, new Vector3(x - 5.5f, 3.5f - y, 0), Quaternion.identity, gameObject.transform);
                    node.GetComponent<Node>().setStatus(Node.NodeStatus.Breakable);
                    mapNodes[x, y] = node;
                }
                if (tile == null)
                {
                    GameObject node = Instantiate(nodePrefab, new Vector3(x - 5.5f,3.5f - y,0), Quaternion.identity, gameObject.transform);
                    node.GetComponent<Node>().setStatus(Node.NodeStatus.);
                    mapNodes[x, y] = node;
                }
            }
        }
    }

    private void Update()
    {
        Debug.Log(mapNodes);
    }

    private void AStarTraversal()
    {

    }
}

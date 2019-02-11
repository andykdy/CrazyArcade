using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Controller : MonoBehaviour
{

    public float speed;
    public float expPower;
    public float maxBomb;

    public GameObject bombPrefab;
    public Tilemap tileMap;
    public Queue<GameObject> myBombs;

    private Rigidbody2D _body;
    private CircleCollider2D _collider;
    private Vector2 velocity;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        myBombs = new Queue<GameObject>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = moveInput.normalized * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int cell = tileMap.WorldToCell(_body.position);
            Vector3 cellCenterPos = tileMap.GetCellCenterWorld(cell);
            //if (myBombs.Count < maxBomb)
            //{
            //    GameObject bomb = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
            //    bomb.GetComponent<Bomb>().explosionPower = expPower;
            //    myBombs.Enqueue(bomb);
            //}
            GameObject bomb = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
            bomb.GetComponent<Bomb>().explosionPower = expPower;
            myBombs.Enqueue(bomb);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            speed = 0f;
        }
        Debug.Log("Triggered with: " + collision.gameObject.name);
    }



    private void FixedUpdate()
    {
        _body.velocity = (velocity * Time.fixedDeltaTime);
    }
}
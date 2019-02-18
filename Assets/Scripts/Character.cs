using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Character : MonoBehaviour
{
    public float speed;
    public float expPower;
    public float maxBomb;

    public GameObject bombPrefab;
    public Tilemap tileMap;
    public Queue<GameObject> myBombs;

    protected Rigidbody2D _body;
    protected CircleCollider2D _collider;
    protected Vector2 velocity;

    protected virtual void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        myBombs = new Queue<GameObject>();
    }

    protected virtual void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = moveInput.normalized * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int cell = tileMap.WorldToCell(_body.position);
            Vector3 cellCenterPos = tileMap.GetCellCenterWorld(cell);
            if (myBombs.Count < maxBomb)
            {
                GameObject bomb = Instantiate(bombPrefab, cellCenterPos, Quaternion.identity);
                bomb.GetComponent<Bomb>().explosionPower = expPower;
                bomb.GetComponent<Bomb>().owner = gameObject;
                myBombs.Enqueue(bomb);
            }
        }
    }

    public void dequeueBomb()
    {
        myBombs.Dequeue();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            speed = 0f;
        }
    }



    protected virtual void FixedUpdate()
    {
        _body.velocity = (velocity * Time.fixedDeltaTime);
    }
}

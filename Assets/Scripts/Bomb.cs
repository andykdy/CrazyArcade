using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 2f;
    public float explosionPower;
    public GameObject owner;


    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            FindObjectOfType<MapDestructor>().Explode(transform.position, explosionPower);
            Destroy(gameObject);
            owner.GetComponent<Character>().dequeueBomb();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            FindObjectOfType<MapDestructor>().Explode(transform.position, explosionPower);
            Destroy(gameObject);
            owner.GetComponent<Character>().dequeueBomb();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}

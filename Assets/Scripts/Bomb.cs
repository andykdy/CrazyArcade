using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown = 2f;
    public float explosionPower;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            FindObjectOfType<MapDestructor>().Explode(transform.position, explosionPower);
            //player.GetComponent<Controller>().myBombs.Dequeue();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            Debug.Log("Bomb hit ");
            FindObjectOfType<MapDestructor>().Explode(transform.position, explosionPower);
            //player.GetComponent<Controller>().myBombs.Dequeue();
            Destroy(gameObject);
        }
        Debug.Log("I triggered");
    }
}

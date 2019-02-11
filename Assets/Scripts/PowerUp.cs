using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float maxSpeed = 600f;
    private float maxPower = 7f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision);
        }
    }

    void PickUp(Collider2D player)
    {
        Controller stats = player.GetComponent<Controller>();
        stats.speed = Mathf.Min(stats.speed + 100, maxSpeed);
        stats.expPower = Mathf.Min(stats.expPower + 1, maxPower);
        Destroy(gameObject);
    }
}

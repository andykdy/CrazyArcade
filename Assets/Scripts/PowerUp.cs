using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected float maxSpeed = 600f;
    protected float maxPower = 7f;
    protected float maxBomb = 6f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp(collision);
        }
    }

    protected virtual void PickUp(Collider2D player)
    {
        
    }
}

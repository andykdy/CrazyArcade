using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPU : PowerUp
{
    protected override void PickUp(Collider2D player)
    {
        Character stats = player.GetComponent<Character>();
        stats.speed = Mathf.Min(stats.speed + 50, maxSpeed);
        Destroy(gameObject);
    }
}

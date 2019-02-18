using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUpPU : PowerUp
{
    protected override void PickUp(Collider2D player)
    {
        Character stats = player.GetComponent<Character>();
        stats.maxBomb = Mathf.Min(stats.expPower + 1, maxBomb);
        Destroy(gameObject);
    }
}

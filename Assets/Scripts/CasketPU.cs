using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasketPU : PowerUp
{
    protected override void PickUp(Collider2D player)
    {
        Character stats = player.GetComponent<Character>();
        stats.expPower = Mathf.Min(stats.expPower + 1, maxPower);
        Destroy(gameObject);
    }
}

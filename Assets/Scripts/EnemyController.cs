using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyController : Character
{
	protected override void Update()
	{
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		velocity = moveInput.normalized * speed;
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
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

	public void setVelocity(Vector2 vel)
	{
		_body.velocity = vel;
	}
}

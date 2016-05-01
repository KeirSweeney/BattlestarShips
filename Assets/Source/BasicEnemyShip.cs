﻿using UnityEngine;
using System.Collections;

public class BasicEnemyShip : EnemyShip 
{

	private const int SHIP_HEALTH = 100;
	private const float SHIP_SPEED = 1.0f;

    void Awake()
    {
        setHealth(SHIP_HEALTH);
        setSpeed(SHIP_SPEED);
    }

	public override void updateShipMovement()
	{
		gameObject.transform.Translate(Vector2.down * Time.deltaTime);
	}

}

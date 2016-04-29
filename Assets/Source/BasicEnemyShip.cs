using UnityEngine;
using System.Collections;

public class BasicEnemyShip : EnemyShip 
{

	private const int HEALTH = 100;
	private const float SPEED = 1.0f;

	public override void updateShipMovement()
	{
		gameObject.transform.Translate(Vector2.down * Time.deltaTime);
	}

	public override void setHealth(int health)
	{
		base.setHealth(HEALTH);
	}

	public override void setSpeed(float speed)
	{
		base.setSpeed(SPEED);
	}
	
}

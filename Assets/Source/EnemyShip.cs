﻿using UnityEngine;
using System.Collections;


public abstract class EnemyShip : MonoBehaviour 
{
    public delegate void destroyEnemyHandler(EnemyShip enemyShip);
    public static event destroyEnemyHandler onDestroyEnemy;

    private int m_health;
    private float m_speed;

    void Update()
    {
        updateShipMovement();
    }

    public abstract void updateShipMovement();

    protected void setHealth(int health)
    {
        m_health = health;
    }

    protected void setSpeed(float speed)
    {
        m_speed = speed;
    }

    void destroyShip()
    {
        if (onDestroyEnemy != null)
        {
            onDestroyEnemy(this);
        }
    }

    void deductHealth(int amountToDeduct)
    {
        m_health -= amountToDeduct;
        if (m_health <= 0)
        {
            destroyShip();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "OffScreenTrigger")
        { 
            destroyShip();
        }

        if(col.gameObject.tag == "Bullet") 
        {
            col.GetComponent<BulletHandler>().StopAllCoroutines();
            col.GetComponent<BulletHandler>().ResetBullet();
            deductHealth(50);
            GameManagerScript.Instance.IncrementScore(10);
        }

        if(col.gameObject.tag == "Player")
        {
            col.GetComponent<Player>().DeductHealth(10);
            destroyShip();
        }
    }
}

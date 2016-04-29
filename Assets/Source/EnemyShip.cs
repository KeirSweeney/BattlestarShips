using UnityEngine;
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

    public virtual void setHealth(int health)
    {
        m_health = health;

        if (m_health == 0)
        {
            destroyShip();
        }
    }

    public virtual void setSpeed(float speed)
    {
        m_speed = speed;
    }

    //create an event 
    void destroyShip()
    {
        if (onDestroyEnemy != null)
        {
            onDestroyEnemy(this);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //off screen trigger tag
        /*if(col.tag == "adoahs;dlasd")
        { 
            destroyShip();
        }*/

        if(col.tag == "bullet") 
        {
            setHealth(--m_health);
        }
        
    }
}

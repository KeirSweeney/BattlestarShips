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

    protected void setHealth(int health)
    {
        m_health = health;
    }

    protected void setSpeed(float speed)
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
        //off screen trigger tag
        if(col.gameObject.tag == "OffScreenTrigger")
        { 
            destroyShip();
        }

        if(col.gameObject.tag == "Bullet") 
        {
            Debug.Log("Remove health");
            col.GetComponent<BulletHandler>().StopAllCoroutines();
            col.GetComponent<BulletHandler>().ResetBullet();
            deductHealth(25);
        }
        
    }
}

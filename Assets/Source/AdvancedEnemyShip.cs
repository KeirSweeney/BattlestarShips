using UnityEngine;
using System.Collections;
using System;

public class AdvancedEnemyShip : EnemyShip
{
    private const int SHIP_HEALTH = 50;
    private const float SHIP_SPEED = 1.5f;

    private Vector3 m_startPos;

    [SerializeField] GameObject m_offScreenTrigger;
    Vector3 m_triggerPos;

    private float m_startTime;
    private float m_journeyTime = 3.0F;

    void Awake()
    {
        setHealth(SHIP_HEALTH);
        setSpeed(SHIP_SPEED);
    }

    void Start()
    {
        m_startPos = transform.position;
        m_triggerPos = m_offScreenTrigger.transform.position;
        m_startTime = Time.time;
    }

    public override void updateShipMovement()
    {
        Vector3 center = (m_startPos + m_triggerPos) * 0.5f;
        center -= new Vector3(0, 1, 0);
        Vector3 riseRelCenter = m_startPos - center;
        Vector3 setRelCenter = m_triggerPos - center;
        float fracComplete = (Time.time - m_startTime) / m_journeyTime;
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }
}

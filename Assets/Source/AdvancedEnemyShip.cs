using UnityEngine;
using System.Collections;
using System;

public class AdvancedEnemyShip : EnemyShip
{
    [SerializeField] GameObject m_offScreenTrigger;

    private const int SHIP_HEALTH = 100;
    private const float SHIP_SPEED = 1.5f;

    private Vector3 m_startPos;
    private Vector3 m_triggerPos;
    private Vector3 m_riseRelCenter;
    private Vector3 m_setRelCenter;
    private Vector3 center;
    private float m_fracComplete;
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
        center = (m_startPos + m_triggerPos) * 0.5f;
        center -= new Vector3(0, 1, 0);
    }

    public override void updateShipMovement()
    {
        m_riseRelCenter = m_startPos - center;
        m_setRelCenter = m_triggerPos - center;
        m_fracComplete = (Time.time - m_startTime) / m_journeyTime;
        transform.position = Vector3.Slerp(m_riseRelCenter, m_setRelCenter, m_fracComplete);
        transform.position += center;
    }
}

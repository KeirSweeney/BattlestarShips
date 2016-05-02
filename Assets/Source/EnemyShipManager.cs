using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyShipManager : MonoBehaviour
{
	[SerializeField] private EnemyShip[] m_allShips;

	private List<EnemyShip> m_enemyShips;

	void Awake()
	{
		m_enemyShips = new List<EnemyShip>();
	}

	void OnEnable()
	{
		EnemyShip.onDestroyEnemy += onDestroyShip;
	}

	void OnDisable()
	{
		EnemyShip.onDestroyEnemy -= onDestroyShip;
	}

	void onDestroyShip(EnemyShip enemyShip)
	{
		m_enemyShips.Remove(enemyShip);
		Destroy(enemyShip.gameObject);
	}

	void Update () 
	{
		if (UnityEngine.Random.Range(0,40) == 0)
		{
			Vector2 position = Camera.main.ScreenToWorldPoint(new Vector2(UnityEngine.Random.Range(0.0f, Screen.width), Screen.height));
			m_enemyShips.Add(Instantiate(m_allShips[UnityEngine.Random.Range(0, m_allShips.Length)], position, Quaternion.identity) as EnemyShip);
		}
	}
}

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
		//picks up the listener, call destroy ship with this.
		EnemyShip.onDestroyEnemy += onDestroyShip;
	}

	void OnDisable()
	{
		//kill of the listener
		EnemyShip.onDestroyEnemy -= onDestroyShip;
	}

	void onDestroyShip(EnemyShip enemyShip)
	{
		m_enemyShips.Remove(enemyShip);
		Destroy(enemyShip.gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (UnityEngine.Random.Range(0,5) == 0)
		{
			Vector2 position = Camera.main.ScreenToWorldPoint(new Vector2(UnityEngine.Random.Range(0.0f, Screen.width), Screen.height));
			m_enemyShips.Add(Instantiate(m_allShips[UnityEngine.Random.Range(0, m_allShips.Length)], position, Quaternion.identity) as EnemyShip);
		}


	}
}

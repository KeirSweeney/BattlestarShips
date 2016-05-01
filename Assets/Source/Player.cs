using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public delegate void GameOverHandler(Player player);
    public static event GameOverHandler onGameOver;

    private int m_health;

	// Use this for initialization
	void Awake ()
    {
        m_health = 100;
	}

    public void DeductHealth(int healthToDeduct)
    {
        m_health -= healthToDeduct;
        GameManagerScript.Instance.DecrementHealth(healthToDeduct);

        if (m_health <= 0)
        {
            onGameOver(this);
        }
    }

    public void SetHealth(int health)
    {
        m_health = health;
    }
}

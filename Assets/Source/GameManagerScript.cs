using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : Singleton<GameManagerScript>
{
    protected GameManagerScript() { }

    private int m_score;
    private int m_playerHealth;
    [SerializeField] private Text m_scoreText;
    [SerializeField] private Text m_playerHealthText;
    [SerializeField] private Button m_restartButton;
    [SerializeField] private Player m_player;

    void OnEnable()
    {
        //picks up the listener, call destroy ship with this.
        Player.onGameOver += onEndGame;
    }

    void OnDisable()
    {
        //kill of the listener
        Player.onGameOver -= onEndGame;
    }


    // Use this for initialization
    void Start()
    {
        m_score = 0;
        m_playerHealth = 100;

        m_scoreText.text = m_score.ToString();
        m_playerHealthText.text = m_playerHealth.ToString();
    }


    public void RestartGame()
    {
        m_restartButton.gameObject.SetActive(false);
        ResetPlayer();

        m_score = 0;

        m_playerHealth = 100;
        m_player.SetHealth(m_playerHealth);

        m_scoreText.text = m_score.ToString();
        m_playerHealthText.text = m_playerHealth.ToString();

    }

    void onEndGame(Player player)
    {
        m_player = player;
        m_restartButton.gameObject.SetActive(true);
        m_player.gameObject.SetActive(false);      
    }

    public void IncrementScore(int scoreIncrement)
    {
        m_score += scoreIncrement;
        m_scoreText.text = m_score.ToString();
    }

    public void DecrementHealth(int healthDecrement)
    {
        m_playerHealth -= healthDecrement;
        m_playerHealthText.text = m_playerHealth.ToString();
    }

    void ResetPlayer()
    {
        m_player.gameObject.transform.position = new Vector2(-2.0f, 0);
        m_player.gameObject.SetActive(true);
        
        
    }
}

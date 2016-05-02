using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManagerScript : Singleton<GameManagerScript>
{
    protected GameManagerScript() { } // guarantee this will be always a singleton only - can't use the constructor!

    [SerializeField] private Text m_scoreText;
    [SerializeField] private Text m_playerHealthText;
    [SerializeField] private Button m_restartButton;
    [SerializeField] private Player m_player;

    private int m_score;

    void OnEnable()
    {
        Player.onGameOver += onEndGame;
    }

    void OnDisable()
    {
        Player.onGameOver -= onEndGame;
    }

    void Start()
    {
        SetGUIValues();
    }

    public void RestartGame()
    {
        ResetPlayer();
        SetGUIValues();
    }

    void SetGUIValues()
    {
        m_restartButton.gameObject.SetActive(false);
        m_score = 0;
        m_player.SetHealth(100);
        m_scoreText.text = m_score.ToString();
        m_playerHealthText.text = m_player.GetHealth().ToString();
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
        m_playerHealthText.text = m_player.GetHealth().ToString();
    }

    void ResetPlayer()
    {
        m_player.gameObject.transform.position = new Vector2(-2.0f, 0);
        m_player.gameObject.SetActive(true);
    }
}

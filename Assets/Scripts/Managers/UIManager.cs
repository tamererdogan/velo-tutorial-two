using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //SINGLETON
    public static UIManager Instance { get; private set; }

    //UI
    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    TMP_Text healthText;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TMP_Text gameOverHighScoreText;

    [SerializeField]
    TMP_Text gameOverScoreText;

    //SINGLETON
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(float score)
    {
        scoreText.text = "Skor: " + ((int)score);
    }

    public void UpdateHealth(float health)
    {
        healthText.text = "Can: " + health;
    }

    public void OpenGameOverPanel(float score, float highScore)
    {
        scoreText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        gameOverHighScoreText.text = "Yüksek Skor: " + ((int)highScore);
        gameOverScoreText.text = "Skor: " + ((int)score);
    }

    public void CloseGameOverPanel()
    {
        scoreText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        gameOverHighScoreText.text = "Yüksek Skor: 0";
        gameOverScoreText.text = "Skor: 0";
    }
}

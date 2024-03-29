using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    //SINGLETON
    public static GameplayManager Instance { get; private set; }

    //GAMEPLAY VARIABLES
    public float speed { get; private set; }
    public float score { get; private set; }
    public float health { get; private set; }

    [SerializeField]
    public float speedUpValue;

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

    //GAMEPLAY
    void Start()
    {
        speed = 5f;
        score = 0;
        health = 3;
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.UpdateHealth(health);
    }

    void FixedUpdate()
    {
        score += speed * Time.fixedDeltaTime;
        UIManager.Instance.UpdateScore(score);
    }

    public void SpeedUp()
    {
        speed += speedUpValue;
    }

    public void Collect(string collactableTagName)
    {
        if (PlayerManager.Instance.isBlink)
            return;

        float point;
        switch (collactableTagName)
        {
            case "Coin":
                point = 100;
                break;
            case "Card":
                point = 50;
                break;
            default:
                point = 0;
                break;
        }

        score += point;
        UIManager.Instance.UpdateScore(score);
    }

    public void HitObstacle()
    {
        if (PlayerManager.Instance.isBlink)
            return;

        health -= 1;
        UIManager.Instance.UpdateHealth(health);
        StartCoroutine(PlayerManager.Instance.Blink());

        if (health <= 0)
            gameOverAction();
    }

    private void gameOverAction()
    {
        Time.timeScale = 0f;
        float highScore = PlayerPrefs.GetFloat("highScore", 0f);
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", score);
            highScore = score;
        }

        UIManager.Instance.OpenGameOverPanel(score, highScore);
    }

    public void playAgainAction()
    {
        Time.timeScale = 1.0f;
        UIManager.Instance.CloseGameOverPanel();
        SceneManager.LoadScene("Game");
    }

    public void exitGameAction()
    {
        Application.Quit();
    }
}

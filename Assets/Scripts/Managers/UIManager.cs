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
}

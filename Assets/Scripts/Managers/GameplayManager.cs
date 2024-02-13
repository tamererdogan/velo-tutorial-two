using UnityEngine;

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
}

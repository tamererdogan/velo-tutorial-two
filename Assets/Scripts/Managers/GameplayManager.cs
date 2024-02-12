using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    //SINGLETON
    public static GameplayManager Instance { get; private set; }

    //GAMEPLAY VARIABLES
    public float speed { get; private set; }

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
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    GameObject playerHolder;

    void Start()
    {
        playerHolder = new GameObject("Player");
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, playerHolder.transform);
        playerHolder.transform.position = new Vector3(0, 0.5f, 2);
    }
}

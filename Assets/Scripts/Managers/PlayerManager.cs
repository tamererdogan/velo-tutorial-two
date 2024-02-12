using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    Vector3 positionOffset;

    [SerializeField]
    Quaternion rotationOffset;

    GameObject playerHolder;

    void Start()
    {
        playerHolder = new GameObject("Player");
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity, playerHolder.transform);
        playerHolder.transform.position = positionOffset;
        playerHolder.transform.rotation = rotationOffset;
    }
}

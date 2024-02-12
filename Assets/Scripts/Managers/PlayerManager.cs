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

    Animator animator;

    void Start()
    {
        playerHolder = new GameObject("Player");
        GameObject player = Instantiate(
            playerPrefab,
            Vector3.zero,
            Quaternion.identity,
            playerHolder.transform
        );
        playerHolder.transform.position = positionOffset;
        playerHolder.transform.rotation = rotationOffset;
        animator = player.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // animator.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump");
        }
        // else
        // {
        //     animator.Play("Run Forward");
        // }
    }
}

using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //SINGLETON
    public static PlayerManager Instance { get; private set; }

    [SerializeField]
    float moveStep = 2f;

    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float jumpForce = 200f;

    Animator animator;

    Rigidbody rb;

    BoxCollider boxCollider;

    SkinnedMeshRenderer skinnedMeshRenderer;

    bool isJump = false;

    bool isSlide = false;

    int currentPosition = 0;

    public bool isBlink { get; private set; }

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

    void Start()
    {
        isBlink = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    void Update()
    {
        if (!isSlide && !isJump && Input.GetKeyDown(KeyCode.W))
        {
            isJump = true;
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (!isSlide && !isJump && Input.GetKeyDown(KeyCode.S))
        {
            isSlide = true;
            boxCollider.center = new Vector3(0, 0.35f, 0);
            boxCollider.size = new Vector3(0.5f, 0.7f, 0.5f);
        }

        if (currentPosition != -1 && Input.GetKeyDown(KeyCode.A))
            currentPosition -= 1;

        if (currentPosition != 1 && Input.GetKeyDown(KeyCode.D))
            currentPosition += 1;

        float wantedX = Mathf.Lerp(
            rb.position.x,
            currentPosition * moveStep,
            moveSpeed * Time.deltaTime
        );

        rb.MovePosition(new Vector3(wantedX, rb.position.y, rb.position.z));

        animator.SetBool("Jump", isJump);
        animator.SetBool("Slide", isSlide);
    }

    public IEnumerator Blink()
    {
        isBlink = true;
        skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        skinnedMeshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        skinnedMeshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        skinnedMeshRenderer.material.color = Color.white;
        isBlink = false;
    }

    void SlideAnimExit()
    {
        isSlide = false;
        animator.SetBool("Slide", isSlide);
        boxCollider.center = new Vector3(0, 0.9f, 0);
        boxCollider.size = new Vector3(0.5f, 1.8f, 0.5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isJump = false;
    }
}

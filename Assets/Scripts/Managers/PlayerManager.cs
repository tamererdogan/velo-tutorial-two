using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 200f;

    Animator animator;

    Rigidbody rb;
    BoxCollider boxCollider;

    bool isJump = false;
    bool isSlide = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (!isSlide && !isJump && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJump = true;
        }

        if (!isSlide && !isJump && Input.GetKeyDown(KeyCode.S))
        {
            isSlide = true;
            boxCollider.center = new Vector3(0, 0.35f, 0);
            boxCollider.size = new Vector3(0.5f, 0.7f, 0.5f);
        }

        animator.SetBool("Jump", isJump);
        animator.SetBool("Slide", isSlide);
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

using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 200f;

    Animator animator;

    Rigidbody rb;

    bool isJump = false;
    bool isSlide = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isSlide && !isJump && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJump = true;
        }

        if (!isSlide && !isJump && Input.GetKeyDown(KeyCode.S))
            isSlide = true;

        animator.SetBool("Jump", isJump);
        animator.SetBool("Slide", isSlide);
    }

    void SlideAnimExit()
    {
        isSlide = false;
        animator.SetBool("Slide", isSlide);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isJump = false;
    }
}

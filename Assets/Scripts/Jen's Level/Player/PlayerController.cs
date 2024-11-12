using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 0;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isGrounded = true; 

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetInteger("Speed", 2);
        }
        else
        {
            animator.SetInteger("Speed", 0);
        }

        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 0;
    public float jumpForce = 3f;
    public float dashForce = 3f;
    public float dashCooldown = 30f;
    private bool isJumping = false;
    private bool isGrounded = true;
    private bool isDashing = false;
    private bool canDash = true;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true;
    private Transform respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        GameObject respawnObject = GameObject.Find("Respawn");
        if (respawnObject != null)
        {
            respawnPoint = respawnObject.transform;
        }
        else
        {
            Debug.LogError("Respawn point not found in the scene!");
        }
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

        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float dashDirection = isFacingRight ? 1 : -1;
        rb.AddForce(new Vector2(dashDirection * dashForce, 0), ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f);

        isDashing = false;

        StartCoroutine(DashCooldown());
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Object"))
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("jumping", false);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isDashing)
            {
                Destroy(collision.gameObject);
                StopCoroutine(DashCooldown());
                canDash = true;
            }
            else
            {
                DieAndRespawn();
            }
        }
    }

    public void DieAndRespawn()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            Debug.LogError("Respawn point not assigned!");
        }
    }
}

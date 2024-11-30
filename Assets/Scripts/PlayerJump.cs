using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Animator anim;
    [SerializeField] float jumpForce;
    public bool doubleJump = true;
    public bool onGround = true;
    Rigidbody2D rb;
    public Ladder ladder;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround == true || doubleJump == true))
        {
            if(ladder.climbing)
            {
                ladder.ExitLadder();
            }
            anim.SetBool("jumpStart", true);
            anim.SetBool("jumping", false);
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if(!onGround)
            {
                doubleJump = false;
            }
        }
        if(rb.velocity.y > 0 && !onGround)
        {
            anim.SetBool("jumpStart", false);
            anim.SetBool("jumping", true);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("jumping", false);
            anim.SetBool("jumpStart", false);
            onGround = true;
            doubleJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
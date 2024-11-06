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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround == true || doubleJump == true))
        {
            anim.SetBool("jumpStart", true);
            anim.SetBool("jumpFall", false);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if(!onGround)
            {
                doubleJump = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("jumpStart", false);
            anim.SetBool("jumpFall", false);
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
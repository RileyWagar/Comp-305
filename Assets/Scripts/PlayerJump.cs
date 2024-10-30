using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpForce;
    public bool doubleJump = true;
    public bool onGround = true;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (onGround == true || doubleJump == true))
        {
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool touchingLadder;
    public bool climbing;
    public PlayerMovement movement;
    public PlayerDash dash;
    public PlayerJump jump;
    Vector3 ladderPos;
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] float climbSpeed;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(touchingLadder && Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("climbing", true);
            climbing = true;
            movement.stopMoving = true;
        }
        if(climbing && Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + climbSpeed, transform.position.z);
        }
        if(climbing)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(ladderPos.x, transform.position.y, transform.position.z);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ladder")
        {
            touchingLadder = true;
            ladderPos = other.transform.position;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ladder")
        {
            anim.SetBool("climbing", false);
            touchingLadder = false;
            movement.stopMoving = false;
            climbing = false;
        }
    }
}
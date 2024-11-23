using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    public GameObject footstep;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float moveSpeedIncrease;
    public float moveSpeed = 0;
    public bool stopMoving = false;
    public bool hit;
    bool stun;
    public PlayerJump jump;
    string direction;
    [SerializeField] float upKnockback;
    [SerializeField] float backKnockback;
    Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if(!stopMoving)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (moveSpeed < maxMoveSpeed)
                {
                    moveSpeed = moveSpeed + moveSpeedIncrease;
                }
                if (moveSpeed >= maxMoveSpeed)
                {
                    moveSpeed = maxMoveSpeed;
                }
                anim.SetFloat("speed", moveSpeed);
                transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
                sprite.flipX = false;
                direction = "right";
                if(jump.onGround)
                {
                    Footsteps();
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (moveSpeed < maxMoveSpeed)
                {
                    moveSpeed = moveSpeed + moveSpeedIncrease;
                }
                if (moveSpeed >= maxMoveSpeed)
                {
                    moveSpeed = maxMoveSpeed;
                }
                anim.SetFloat("speed", moveSpeed);
                transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
                sprite.flipX = true;
                direction = "left";
                if (jump.onGround)
                {
                    Footsteps();
                }
            }
            if(Input.GetKey(KeyCode.S))
            {
                anim.SetBool("crouch", true);
            }
            if (!Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("crouch", false);
            }
        }
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("speed", moveSpeed);
            moveSpeed = 0;
            StopFootSteps();
        }
        if(!jump.onGround)
        {
            StopFootSteps();
        }
        if(hit)
        {
            rb.velocity = new Vector3(0, 0, 0);
            stopMoving = true;
            stun = true;
            rb.AddForce(Vector2.up * upKnockback, ForceMode2D.Impulse);
            if(direction == "right")
            {
                Debug.Log(direction);
                rb.AddForce(Vector2.left * backKnockback, ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log(direction + "1");
                rb.AddForce(Vector2.left * -backKnockback, ForceMode2D.Impulse);
            }
            hit = false;
        }
    }
    void Footsteps()
    {
        footstep.SetActive(true);
    }
    void StopFootSteps()
    {
        footstep.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground" && stun)
        {
            stun = false;
            stopMoving = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
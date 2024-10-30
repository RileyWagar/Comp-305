using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] float dashSpeed;
    [SerializeField] int dashFreezeMax;
    [SerializeField] int dashDurationMax;
    public PlayerMovement movement;
    public DashCollision collision;
    Rigidbody2D rb;
    public bool dash = true;
    int dashDuration;
    bool dashing;
    bool dashUp;
    bool dashLeft;
    bool dashRight;
    bool dashDown;
    bool dashUpLeft;
    bool dashUpRight;
    bool dashDownLeft;
    bool dashDownRight;
    int dashFreezeTimer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashDuration = dashDurationMax;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && dash)
        {
            if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashUpLeft = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashDownLeft = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashUpRight = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashDownRight = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashLeft = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashRight = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashUp = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector3(0, 0, 0);
                dashDown = true;
                dash = false;
                collision.dashing = true;
                movement.moveSpeed = 0;
            }
        }
        if(dashUp)
        {
            DashUp();
        }
        if(dashLeft)
        {
            DashLeft();
        }
        if(dashRight)
        {
            DashRight();
        }
        if(dashDown)
        {
            DashDown();
        }
        if(dashUpRight)
        {
            DashUpRight();
        }
        if(dashUpLeft)
        {
            DashUpLeft();
        }
        if(dashDownRight)
        {
            DashDownRight();
        }
        if(dashDownLeft)
        {
            DashDownLeft();
        }
        if(dashFreezeTimer > 0)
        {
            movement.stopMoving = true;
            dashFreezeTimer--;
            rb.velocity = new Vector3(0, 0, 0);
            if(dashFreezeTimer <= 0)
            {
                movement.stopMoving = false;
            }
        }
    }
    void DashUp()
    {
        if(dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x, transform.position.y + dashSpeed, transform.position.z);
        }
        if(dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashUp = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashLeft()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x - dashSpeed, transform.position.y, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashLeft = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashRight()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x + dashSpeed, transform.position.y, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashRight = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashDown()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x, transform.position.y - dashSpeed, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashDown = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashUpLeft()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x - dashSpeed, transform.position.y + dashSpeed, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashUpLeft = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashUpRight()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x + dashSpeed, transform.position.y + dashSpeed, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashUpRight = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashDownLeft()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x - dashSpeed, transform.position.y - dashSpeed, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashDownLeft = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void DashDownRight()
    {
        if (dashDuration > 0)
        {
            dashing = true;
            dashDuration--;
            transform.position = new Vector3(transform.position.x + dashSpeed, transform.position.y - dashSpeed, transform.position.z);
        }
        if (dashDuration <= 0)
        {
            dashFreezeTimer = dashFreezeMax;
            dashDownRight = false;
            dashing = false;
            dashDuration = dashDurationMax;
            collision.dashing = false;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            dash = true;
        }
    }
}
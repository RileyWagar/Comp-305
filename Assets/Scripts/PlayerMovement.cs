using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float moveSpeedIncrease;
    public float moveSpeed = 0;
    public bool stopMoving = false;
    void Start()
    {
        anim = GetComponent<Animator>();
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
        }
    }
}
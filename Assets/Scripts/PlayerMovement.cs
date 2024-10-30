using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float moveSpeedIncrease;
    public float moveSpeed = 0;
    public bool stopMoving = false;
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
                transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
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
                transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
            }
        }
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            moveSpeed = 0;
        }
    }
}
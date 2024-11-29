using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    Vector3 checkpoint;
    bool start = true;
    public PlayerMovement movement;
    public PlayerDash dash;
    public PlayerJump jump;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(PlayerStats.health <= 0)
        {
            transform.position = checkpoint;
            PlayerStats.health = 3;
        }
        if(start)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = PlayerStats.checkpoint;
            start = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "End")
        {
            if(checkpoint == new Vector3(-8.9f, -4.45f, 0))
            {
                checkpoint = new Vector3(261.6f, -3.479763f, 0);
            }
            else if(checkpoint == new Vector3(261.6f, -3.479763f, 0))
            {
                checkpoint = new Vector3(325.2f, -2.84f, 0);
            }
            else if(checkpoint == new Vector3(325.2f, -2.84f, 0))
            {

            }
            transform.position = checkpoint;
        }
        if(other.tag == "Void")
        {
            PlayerStats.health = 0;
        }
    }
}
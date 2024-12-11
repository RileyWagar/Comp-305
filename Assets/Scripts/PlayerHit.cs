using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerDash dash;
    public PlayerMovement movement;
    public PlayerJump jump;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !dash.dashing)
        {
            PlayerStats.health--;
            if(PlayerStats.health > 0)
            {
                movement.hit = true;
                jump.hit = true;
                dash.hit = true;
            }
        }

        if (other.tag == "Turrent" && !dash.dashing)
        {
            PlayerStats.health--;
            if (PlayerStats.health > 0)
            {
                movement.hit = true;
                jump.hit = true;
                dash.hit = true;
            }
        }
    }
}
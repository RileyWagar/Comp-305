using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerDash dash;
    public PlayerMovement movement;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !dash.dashing)
        {
            PlayerStats.health--;
            if(PlayerStats.health > 0)
            {
                movement.hit = true;
            }
        }
    }
}
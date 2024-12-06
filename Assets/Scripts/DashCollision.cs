using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCollision : MonoBehaviour
{
    public PlayerDash dash;
    public bool dashing;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && dashing)
        {
            dash.dash = true;
            other.GetComponent<EnemyDestroyed>().destroy = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerDash dash;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && !dash.dashing)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}
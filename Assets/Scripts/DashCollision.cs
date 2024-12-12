using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCollision : MonoBehaviour
{
    public PlayerDash dash;
    public bool dashing;
    public AudioSource source;
    public AudioClip destroyed;
    public bool playAudio = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && dashing)
        {
            source.PlayOneShot(destroyed);
            dash.dash = true;
            other.GetComponent<EnemyDestroyed>().destroy = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHurtbox : MonoBehaviour
{
    public Ladder ladder;
    void Update()
    {
        if(!ladder.climbing)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground" && ladder.climbing)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Hehe");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground" && ladder.climbing)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
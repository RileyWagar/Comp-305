using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    Vector3 checkpoint;
    void Start()
    {
        checkpoint = new Vector3(-8.9f, -4.45f, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "End")
        {
            checkpoint = new Vector3(325.2f, -2.84f, 0);
            transform.position = checkpoint;
        }
        if(other.tag == "Void")
        {
            transform.position = checkpoint;
        }
    }
}
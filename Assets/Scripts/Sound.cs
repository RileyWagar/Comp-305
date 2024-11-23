using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject footstep;
    void Start()
    {
        footstep.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Footsteps();
        }
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            StopFootSteps();
        }
    }
    void Footsteps()
    {
        footstep.SetActive(true);
    }
    void StopFootSteps()
    {
        footstep.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyed : MonoBehaviour
{
    Animator anim;
    public bool destroy;
    [SerializeField] public int timerMax;
    int timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = timerMax;
    }
    void Update()
    {
        if(destroy)
        {
            anim.SetBool("destroyed", true);
            if (timer == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                timer--;
            }
        }
    }
}
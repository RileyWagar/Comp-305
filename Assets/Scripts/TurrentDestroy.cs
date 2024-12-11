using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentDestroy : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component is missing on the turret.");
        }
    }

    public void TriggerDestruction()
    {
            animator.SetBool("Explode", true);

        StartCoroutine(WaitAndDestroy(.5f));
    }

    private IEnumerator WaitAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

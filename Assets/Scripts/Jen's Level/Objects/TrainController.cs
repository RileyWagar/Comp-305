using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed = 1f;
    private Transform startPoint;

    void Start()
    {
        GameObject startObject = GameObject.FindWithTag("Train Start 1");
        if (startObject != null)
        {
            startPoint = startObject.transform;
        }
        else
        {
            Debug.LogError("Train start point not found in the scene!");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Train End"))
        {
            StartCoroutine(RespawnTrain());
        }
    }

    private IEnumerator RespawnTrain()
    {
        this.enabled = false;

        yield return new WaitForSeconds(0.5f);

        transform.position = startPoint.position;

        this.enabled = true;
    }
}

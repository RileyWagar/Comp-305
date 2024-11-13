using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public float speed = 1f;
    private Transform startPoint;

    void Start()
    {
        // Find the start point in the scene
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
        // Continuously move the train forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the train collides with an object tagged "TrainEnd"
        if (other.CompareTag("Train End"))
        {
            StartCoroutine(RespawnTrain());
        }
    }

    private IEnumerator RespawnTrain()
    {
        // Disable the TrainController component to stop Update movement
        this.enabled = false;

        // Wait for a short delay before respawning
        yield return new WaitForSeconds(0.5f);

        // Move the train back to the start point
        transform.position = startPoint.position;

        // Re-enable the TrainController component to resume movement
        this.enabled = true;
    }
}

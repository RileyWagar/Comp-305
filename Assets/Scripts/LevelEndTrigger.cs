using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public GameObject levelEndCanvas; // Assign your canvas in the inspector
    public PlayerMovement movement;
    private void Start()
    {
        if (levelEndCanvas != null)
        {
            // Ensure the canvas is initially inactive
            levelEndCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Level End Canvas is not assigned in the inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding has the "Player" tag
        if (other.CompareTag("Player") && levelEndCanvas != null)
        {
            // Activate the canvas
            levelEndCanvas.SetActive(true);
            movement.stopMoving = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level : MonoBehaviour
{
    Vector3 checkpoint;
    bool start = true;
    public PlayerMovement movement;
    public PlayerDash dash;
    public PlayerJump jump;
    Rigidbody2D rb;
    public SceneSwitcher scene;
    public GameObject levelEndCanvas;
    public PolygonCollider2D borderB;
    public PolygonCollider2D borderC;
    public CinemachineConfiner confiner;
    public CinemachineVirtualCamera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(PlayerStats.health <= 0)
        {
            transform.position = PlayerStats.checkpoint;
            PlayerStats.health = 3;
        }
        if(start)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = PlayerStats.checkpoint;
            start = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "End")
        {
            Debug.Log(PlayerStats.checkpoint);
            if(PlayerStats.checkpoint == new Vector3(77.04f, -12.54f, 0))
            {
                levelEndCanvas.SetActive(true);
                movement.stopMoving = true;
            }
            if (other.name == "Checkpoint A")
            {
                PlayerStats.checkpoint = new Vector3(265f, -3.3f, 0);
                confiner.m_BoundingShape2D = borderB;
                cam.m_Lens.OrthographicSize = 8.1f;
                transform.position = PlayerStats.checkpoint;
            }
            else if(other.name == "Checkpoint B")
            {
                PlayerStats.checkpoint = new Vector3(326f, -3.3f, 0);
                confiner.m_BoundingShape2D = borderC;
                cam.m_Lens.OrthographicSize = 11.8f;
                transform.position = PlayerStats.checkpoint;
            }
            else if(other.name == "End")
            {
                levelEndCanvas.SetActive(true);
                movement.stopMoving = true;
            }    
        }
        if(other.tag == "Void")
        {
            PlayerStats.health = 0;
        }
    }
}
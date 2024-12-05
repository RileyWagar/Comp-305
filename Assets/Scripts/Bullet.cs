using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 
    public float lifespan = 10f; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0f;

        rb.freezeRotation = true;

        rb.velocity = -transform.right * speed;

        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy (gameObject);
    }
}

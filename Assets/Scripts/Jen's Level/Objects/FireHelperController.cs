using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHelperController : MonoBehaviour
{
    public float speed = 2f;
    private bool isFacingRight = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveDirection = isFacingRight ? 1 : -1;
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boarder"))
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

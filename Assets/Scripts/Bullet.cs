using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifespan = 10f;

    private void Start()
    {
       
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }

    private void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}



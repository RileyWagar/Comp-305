using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform shootPoint;      
    public float fireRate = 2f;     
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullet()
    {
        if (bulletPrefab != null && shootPoint != null)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}

using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform shootPoint;       
    public float fireRate = 2f;         
    public float shootingRange = 15f;   
    public Transform player;            
    private float nextFireTime = 0f;

    void Update()
    {

        if (Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
            if (Time.time >= nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void FireBullet()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
}

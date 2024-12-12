using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator anim;
    public GameObject bulletPrefab; 
    public Transform shootPoint;      
    public float fireRate = 2f;     
    private float nextFireTime = 0f;
    public AudioSource source;
    public AudioClip shoot;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("shooting", false);
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
            AudioSource.PlayClipAtPoint(shoot, transform.position, 1f);
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            anim.SetBool("shooting", true);
        }
    }
}
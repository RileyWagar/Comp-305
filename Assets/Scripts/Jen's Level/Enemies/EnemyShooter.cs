using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 1.5f;

    private bool playerInRange = false;
    private Coroutine shootingCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            shootingCoroutine = StartCoroutine(ShootAtPlayer());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }
    }

    private IEnumerator ShootAtPlayer()
    {
        while (playerInRange)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


            yield return new WaitForSeconds(shootInterval);
        }
    }
}

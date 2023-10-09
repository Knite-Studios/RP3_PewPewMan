using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : EnemyAI
{
    public Transform player;
    public float detectionRange = 10f;
    public LayerMask obstaclesLayer;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireCooldown = 0f;
    public float bulletSpeed = 10f; 

    private void Update()
    {
        if (PlayerInRange())
        {
            if (fireCooldown <= 0)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }
        
        fireCooldown -= Time.deltaTime;
    }

    private bool PlayerInRange()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, obstaclesLayer);

        if (hit.collider != null && hit.collider.CompareTag("Player") && distanceToPlayer <= detectionRange)
        {
            return true;
        }

        return false;
    }

    private void Shoot()
    {
        Vector2 direction = (player.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet, 5f);
    }
}

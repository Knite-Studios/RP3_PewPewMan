using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float bulletSpeed = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // damage enemy here
            //collision.gameObject.GetComponent<EnemyAI>().TakeDamage();
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
    }*/
}

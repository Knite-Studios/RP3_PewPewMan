using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float bulletSpeed = 1f;
    [SerializeField]
    private int damage = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int health = 1;

    public virtual void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}

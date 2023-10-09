using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int health = 2;
    public GameObject deathEffectPrefab;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health == 1) // After the first shot
        {
            StartCoroutine(FlashRed());
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private System.Collections.IEnumerator FlashRed()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(1f);
            spriteRenderer.color = Color.white;
        }
    }

    protected virtual void Die()
    {
        Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

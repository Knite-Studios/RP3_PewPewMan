using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int currentHealth = 2;
    public int maxHealth = 2;
  
    public GameObject deathEffectPrefab;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage) //TODO: change this to bullet damage
    {
        currentHealth -= damage;

        if (currentHealth == 1) // After the first shot
        {
            StartCoroutine(FlashRed());
        }

        if (currentHealth <= 0)
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

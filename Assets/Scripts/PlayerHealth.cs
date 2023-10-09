using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData playerData;
    public Slider healthSlider;

    private void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage(int damageAmount)
    {
        playerData.player.health -= damageAmount;
        UpdateHealthUI();

        if (playerData.player.health <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)playerData.player.health / playerData.player.MaxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
    }
}

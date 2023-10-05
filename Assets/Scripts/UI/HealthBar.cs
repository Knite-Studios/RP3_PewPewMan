using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerData data;

    [SerializeField]
    private Slider healthSlider;

    void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    void SetHealth(int health)
    {
        healthSlider.value = health;
    }
    private void Start()
    {
        SetMaxHealth(data.player.MaxHealth);
    }
    private void Update()
    {
        SetHealth(data.player.health);
    }
}

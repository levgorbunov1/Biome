using UnityEngine;

public class HealthSystem : MonoBehaviour, IStatSystem
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    private StatBar hungerBar;

    void Update()
    {
        if (hungerBar != null)
        {
            hungerBar.SetValue(currentHealth);
        }
    }

    public void Damage(int amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);

        if (currentHealth <= 0)
        {

        }
    }

    public void Heal(float amount)
    {
        currentHealth = (int)Mathf.Clamp(currentHealth + amount, 0f, maxHealth);
    }

    public void SetStatBar(StatBar statBar)
    {
        hungerBar = statBar;
    }
}

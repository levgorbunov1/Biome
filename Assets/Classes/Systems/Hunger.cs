using UnityEngine;

public class HungerSystem : MonoBehaviour, IStatSystem
{
    public bool isPlayer = true;
    public Diet diet = Diet.Herbivore;

    public int maxHunger = 100;
    public int currentHunger = 20;
    public float hungerInterval = 2f;
    private float hungerTimer;

    private StatBar healthBar;
    private HealthSystem healthSystem;

    void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (!isPlayer) return;

        hungerTimer += Time.deltaTime;

        if (hungerTimer >= hungerInterval)
        {
            hungerTimer = 0f;
            Starve(5);
        }

        if (healthBar != null)
        {
            healthBar.SetValue(currentHunger);
        }
    }

    void Starve(int amount)
    {
        currentHunger = Mathf.Max(currentHunger - amount, 0);

        if (currentHunger <= 0)
        {
            healthSystem.Damage(5);
        }
    }

    public void Feed(float amount)
    {
        currentHunger = (int)Mathf.Clamp(currentHunger + amount, 0f, maxHunger);
    }

    public void SetStatBar(StatBar statBar)
    {
        healthBar = statBar;
    }
}

using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public Diet diet = Diet.Herbivore;

    public int maxHunger = 100;
    public int currentHunger = 20;
    public float hungerInterval = 2f;
    private float hungerTimer;

    public StatBar hungerBar;

    void Update()
    {
        hungerTimer += Time.deltaTime;

        if (hungerTimer >= hungerInterval)
        {
            hungerTimer = 0f;
            Starve(5);
        }

        if (hungerBar != null)
        {
            hungerBar.SetValue(currentHunger);
        }
        else
        {
            Debug.Log("No hunger bar to update");
        }
    }

    void Starve(int amount)
    {
        currentHunger = Mathf.Max(currentHunger - amount, 0);

        if (currentHunger <= 0)
        {
        }
    }

    public void Feed(float amount)
    {
        currentHunger = (int)Mathf.Clamp(currentHunger + amount, 0f, maxHunger);
    }
}

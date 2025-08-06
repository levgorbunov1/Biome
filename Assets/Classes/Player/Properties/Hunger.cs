using UnityEngine;

public class PlayerHunger : MonoBehaviour
{
    public Diet diet = Diet.Herbivore;

    public int maxHunger = 100;
    public int currentHunger = 100;
    public float hungerInterval = 2f;
    private float hungerTimer;

    void Update()
    {
        hungerTimer += Time.deltaTime;

        if (hungerTimer >= hungerInterval)
        {
            hungerTimer = 0f;
            Starve(1);
        }
    }

    void Starve(int amount)
    {
        currentHunger = Mathf.Max(currentHunger - amount, 0);
        Debug.Log($"Hunger: {currentHunger}");

        if (currentHunger <= 0)
        {
            Debug.Log("Player is starving!");
        }
    }

    public void Feed(float amount)
    {
        currentHunger = (int)Mathf.Clamp(currentHunger + amount, 0f, maxHunger);
    }
}

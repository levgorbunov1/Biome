using UnityEngine;

public class Food : MonoBehaviour
{
    public int foodValue = 20;
    public Diet diet = Diet.Herbivore;

    private void OnTriggerEnter(Collider other)
    {
        HungerSystem hungerSystem = other.GetComponent<HungerSystem>();

        if (hungerSystem != null && diet == hungerSystem.diet)
        {
            hungerSystem.Feed(foodValue);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class PlayerSystems : MonoBehaviour
{
    public HungerSystem hungerSystem;
    public MovementController movementController;

    void Awake()
    {
        hungerSystem = GetComponent<HungerSystem>();
        movementController = GetComponent<MovementController>();
    }
}

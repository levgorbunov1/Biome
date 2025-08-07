using UnityEngine;

public class CharacterControllerSpawner : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject playerPrefab;

    [Header("Spawn Settings")]
    public Vector3 spawnPosition = Vector3.zero;

    void OnEnable()
    {
        GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}

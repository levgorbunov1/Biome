using UnityEngine;

public class aiGenerator : MonoBehaviour
{
    [Header("Prefab Reference")]
    public GameObject aiPrefab;

    [Header("Spawn Settings")]
    public int count = 3;

    void OnEnable()
    {
        ZoneGenerator zoneBoundary = FindFirstObjectByType<ZoneGenerator>();

        for (int i = 0; i < count; i++)
        {
            Spawn(zoneBoundary);
        }
    }

    void Spawn(ZoneGenerator zoneBoundary)
    {
        float zoneWidth = zoneBoundary.zoneWidth;
        float zoneDepth = zoneBoundary.zoneDepth;
        float zoneHeight = zoneBoundary.zoneHeight;
        Vector3 center = zoneBoundary.transform.position;

        Vector3 randomPos = new Vector3(
            Random.Range(center.x - zoneWidth / 2f, center.x + zoneWidth / 2f),
            Random.Range(center.y - zoneHeight / 2f, center.y + zoneHeight / 2f),
            Random.Range(center.z - zoneDepth / 2f, center.z + zoneDepth / 2f)
        );

        GameObject ai = Instantiate(aiPrefab, randomPos, Quaternion.identity);
    }
}

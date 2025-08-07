using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [Header("Prefab Reference")]
    public GameObject foodPrefab;

    [Header("Spawn Settings")]
    public int foodCount = 10;

    void OnEnable()
    {
        ZoneGenerator zoneBoundary = FindFirstObjectByType<ZoneGenerator>();

        if (zoneBoundary == null)
        {
            Debug.LogError("ZoneBoundary2DWall reference is not set!");
            return;
        }

        for (int i = 0; i < foodCount; i++)
        {
            SpawnFood(zoneBoundary);
        }
    }

    void SpawnFood(ZoneGenerator zoneBoundary)
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

        GameObject food = Instantiate(foodPrefab, randomPos, Quaternion.identity);

        bool isHerbivore = Random.value > 0.5f;

        Food foodProperties = food.GetComponent<Food>();
        Renderer rend = food.GetComponent<Renderer>();
        
        foodProperties.diet = isHerbivore ? Diet.Herbivore : Diet.Carnivore;
    
        Color foodColor = isHerbivore ? Color.green : Color.red;
        Material mat = new Material(rend.material);
        mat.color = foodColor;
        rend.material = mat;
    }
}

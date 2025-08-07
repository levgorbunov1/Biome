using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorController : MonoBehaviour
{
    [Header("Generator References")]
    public GameObject uiGenerator;
    public GameObject playerGenerator;
    public GameObject zoneGenerator;
    public GameObject foodGenerator;
    public GameObject terrainGenerator;
    public GameObject AIGenerator;

    void Awake()
    {
        StartCoroutine(InitializeGenerators());
    }

    private IEnumerator InitializeGenerators()
    {
        List<GameObject> generators = new List<GameObject>
        {
            zoneGenerator,
            // terrainGenerator, // Uncomment if/when needed
            foodGenerator,
            AIGenerator,
            playerGenerator,
            uiGenerator
        };

        foreach (GameObject generator in generators)
        {
            if (generator != null)
            {
                generator.SetActive(true);
                yield return null;
            }
        }
    }
}

using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [Header("Generator References")]
    public GameObject uiGenerator;
    public GameObject playerGenerator;
    public GameObject zoneGenerator;
    public GameObject foodGenerator;

    void Awake()
    {
        StartCoroutine(InitializeGenerators());
    }

    private System.Collections.IEnumerator InitializeGenerators()
    {
        if (zoneGenerator != null)
        {
            zoneGenerator.SetActive(true);
            yield return null; 
        }

        if (foodGenerator != null)
        {
            foodGenerator.SetActive(true);
            yield return null; 
        }

        if (playerGenerator != null)
        {
            playerGenerator.SetActive(true);
            yield return null; 
        }
        
        if (uiGenerator != null)
        {
            uiGenerator.SetActive(true);
            yield return null;
        }

        Debug.Log("All generators enabled.");
    }
}

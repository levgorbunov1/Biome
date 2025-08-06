using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    [Header("Generator References")]
    public GameObject uiGenerator;
    public GameObject playerGenerator;

    void Awake()
    {
        StartCoroutine(InitializeGenerators());
    }

    private System.Collections.IEnumerator InitializeGenerators()
    {
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

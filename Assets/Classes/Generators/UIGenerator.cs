using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public StatBar statBarPrefab;
    private Transform canvasTransform;

    private void OnEnable()
    {
        CreateCanvas();
        CreatePlayerStatUI();
    }

    void CreateCanvas()
    {
        GameObject canvasGO = new GameObject("Canvas");
        var canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();
        canvasTransform = canvasGO.transform;
    }

    void CreatePlayerStatUI()
    {
        var statSystems = new (string name, IStatSystem system, Color color)[]

        {
            ("Health", FindFirstObjectByType<HealthSystem>(), Color.red),
            ("Hunger", FindFirstObjectByType<HungerSystem>(), Color.blue),
        };

        int index = 0;

        foreach (var (name, system, color) in statSystems)
        {
            CreateStatBar(name, system, index++, color);
        }
    }

    void CreateStatBar(string statName, IStatSystem system, int index, Color color)
    {
        if (statBarPrefab != null)
        {
            StatBar statBar = Instantiate(statBarPrefab, canvasTransform);

            RectTransform barRT = statBar.GetComponent<RectTransform>();
            barRT.anchorMin = new Vector2(1f, 1f);
            barRT.anchorMax = new Vector2(1f, 1f);
            barRT.pivot = new Vector2(1f, 1f);

            float yOffset = -10f - (index * 30f);
            barRT.anchoredPosition = new Vector2(-80f, yOffset);

            statBar.statName = statName;
            statBar.SetValue(100f);
            statBar.color = color;

            if (system != null)
            {
                system.SetStatBar(statBar);
            }
            else
            {
                Debug.LogWarning($"System not found for stat: {statName}");
            }
        }
        else
        {
            Debug.LogWarning("StatBar prefab not assigned in UIController.");
        }
    }
}
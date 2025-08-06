using UnityEngine;

public class UIController : MonoBehaviour
{
    public StatBar statBarPrefab;

    private StatBar hungerBar;

    void OnEnable()
    {
        GameObject canvasGO = new GameObject("Canvas");
        var canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = UnityEngine.RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<UnityEngine.UI.CanvasScaler>();
        canvasGO.AddComponent<UnityEngine.UI.GraphicRaycaster>();

        if (statBarPrefab != null)
        {
            hungerBar = Instantiate(statBarPrefab, canvasGO.transform);

            RectTransform barRT = hungerBar.GetComponent<RectTransform>();
            barRT.anchorMin = new Vector2(1f, 1f);
            barRT.anchorMax = new Vector2(1f, 1f);
            barRT.pivot = new Vector2(1f, 1f);      
            barRT.anchoredPosition = new Vector2(-80f, -10f);

            hungerBar.statName = "Hunger";
            hungerBar.SetValue(100f);
        }
        else
        {
            Debug.LogWarning("StatBar prefab not assigned in UIController");
        }

        HungerSystem hungerSystem = FindFirstObjectByType<HungerSystem>();

        if (hungerSystem != null)
        {
            hungerSystem.hungerBar = hungerBar;
        }
        else
        {
            Debug.LogWarning("No HungerSystem found in the scene.");
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] private string _statName = "Stat";
    private Slider slider;
    private Text label;

    public float minValue = 0f;
    public float maxValue = 100f;

    public string statName
    {
        get => _statName;
        set
        {
            _statName = value;
            if (label != null)
            {
                label.text = _statName;
            }
        }
    }

    void Awake()
    {
        GameObject sliderGO = new GameObject("Slider");
        sliderGO.transform.SetParent(transform);
        sliderGO.AddComponent<RectTransform>();

        slider = sliderGO.AddComponent<Slider>();

        GameObject backgroundGO = new GameObject("Background");
        backgroundGO.transform.SetParent(sliderGO.transform);
        Image backgroundImage = backgroundGO.AddComponent<Image>();
        backgroundImage.color = Color.gray;
        RectTransform bgRT = backgroundGO.GetComponent<RectTransform>();
        bgRT.anchorMin = Vector2.zero;
        bgRT.anchorMax = Vector2.one;
        bgRT.offsetMin = Vector2.zero;
        bgRT.offsetMax = Vector2.zero;

        GameObject fillAreaGO = new GameObject("Fill Area");
        fillAreaGO.transform.SetParent(sliderGO.transform);
        RectTransform fillAreaRT = fillAreaGO.AddComponent<RectTransform>();
        fillAreaRT.anchorMin = new Vector2(0, 0);
        fillAreaRT.anchorMax = new Vector2(1, 1);
        fillAreaRT.offsetMin = new Vector2(5, 5);
        fillAreaRT.offsetMax = new Vector2(-5, -5);

        GameObject fillGO = new GameObject("Fill");
        fillGO.transform.SetParent(fillAreaGO.transform);
        Image fillImage = fillGO.AddComponent<Image>();
        fillImage.color = Color.blue;
        RectTransform fillRT = fillGO.GetComponent<RectTransform>();
        fillRT.anchorMin = new Vector2(0, 0);
        fillRT.anchorMax = new Vector2(1, 1);
        fillRT.offsetMin = Vector2.zero;
        fillRT.offsetMax = Vector2.zero;

        slider.fillRect = fillRT;
        slider.targetGraphic = fillImage;

        RectTransform sliderRT = sliderGO.GetComponent<RectTransform>();
        sliderRT.sizeDelta = new Vector2(200, 20);
        sliderRT.anchorMin = new Vector2(0.5f, 0);
        sliderRT.anchorMax = new Vector2(0.5f, 0);
        sliderRT.pivot = new Vector2(0.5f, 0);
        sliderRT.anchoredPosition = new Vector2(0, 30);

        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = maxValue;

        GameObject labelGO = new GameObject("Label");
        labelGO.transform.SetParent(transform);
        label = labelGO.AddComponent<Text>();
        label.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        label.text = _statName;
        label.alignment = TextAnchor.MiddleCenter;

        RectTransform labelRT = label.GetComponent<RectTransform>();
        labelRT.sizeDelta = new Vector2(200, 20);
        labelRT.anchorMin = new Vector2(0.5f, 0);
        labelRT.anchorMax = new Vector2(0.5f, 0);
        labelRT.pivot = new Vector2(0.5f, 0);
        labelRT.anchoredPosition = new Vector2(0, 55);
    }

    public void SetValue(float currentValue)
    {
        slider.value = Mathf.Clamp(currentValue, minValue, maxValue);
    }
}

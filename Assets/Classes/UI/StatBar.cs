using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public float minValue = 0f;
    public float maxValue = 100f;

    private Slider slider;
    private Text label;
    private Image fillImage;

    private string _statName;
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

    private Color _color;
    public Color color
    {
        get => _color;
        set
        {
            _color = value;
            if (fillImage != null)
            {
                fillImage.color = _color;
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
        fillImage = fillGO.AddComponent<Image>();
        fillImage.color = color;
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
        labelGO.transform.SetParent(sliderGO.transform);

        label = labelGO.AddComponent<Text>();
        label.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        label.text = _statName;
        label.alignment = TextAnchor.MiddleCenter;
        label.color = Color.white;

        RectTransform labelRT = label.GetComponent<RectTransform>();
        labelRT.anchorMin = new Vector2(0f, 0f);
        labelRT.anchorMax = new Vector2(1f, 1f);
        labelRT.offsetMin = Vector2.zero;
        labelRT.offsetMax = Vector2.zero;
        labelRT.pivot = new Vector2(0.5f, 0.5f);
    }

    public void SetValue(float currentValue)
    {
        slider.value = Mathf.Clamp(currentValue, minValue, maxValue);
    }
}

using UnityEngine;

public class UnderwaterEffect : MonoBehaviour
{
    [Header("Skybox Settings")]
    public Material underwaterSkybox;

    void Start()
    {
        // RenderSettings.fog = true;
        // RenderSettings.fogMode = FogMode.Exponential;
        // RenderSettings.fogDensity = 0.02f;
        // RenderSettings.fogColor = new Color32(106, 189, 207, 255);

        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = new Color(0f, 0.2f, 0.3f);
        
        if (underwaterSkybox != null)
        {
            RenderSettings.skybox = underwaterSkybox;
        }

        Light mainLight = RenderSettings.sun;

        if (mainLight != null)
        {
            mainLight.color = new Color(0.5f, 0.8f, 1f);
            mainLight.intensity = 0f;
        }
    }
}

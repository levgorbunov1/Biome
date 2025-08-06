using UnityEngine;

[RequireComponent(typeof(Camera))]

public class UnderwaterCameraBackground : MonoBehaviour
{
    [Header("Background Color")]
    public Color backgroundColor = new Color32(106, 189, 207, 255);

    void Start()
    {
        Camera cam = GetComponent<Camera>();

        cam.clearFlags = CameraClearFlags.SolidColor;

        cam.backgroundColor = backgroundColor;
        
        RenderSettings.skybox = null;
    }
}

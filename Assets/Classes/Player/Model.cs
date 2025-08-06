using UnityEngine;

public class WormModelGenerator : MonoBehaviour
{
    public int segmentCount = 4;
    public float segmentSpacing = 0.1f;
    public Vector3 segmentScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Material segmentMaterial;

    public Transform[] Segments { get; private set; }
    public Vector3[] BasePositions { get; private set; }
    public Transform WormRoot { get; private set; }

    void Awake()
    {
        GenerateWorm();
    }

    private void GenerateWorm()
    {
        WormRoot = new GameObject("WormBody").transform;
        WormRoot.SetParent(transform);
        WormRoot.localPosition = Vector3.zero;

        Segments = new Transform[segmentCount];
        BasePositions = new Vector3[segmentCount];

        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            segment.transform.localRotation = Quaternion.Euler(90, 0, 0);
            segment.transform.SetParent(WormRoot);
            segment.transform.localScale = segmentScale;

            Collider collider = segment.GetComponent<Collider>();
            collider.isTrigger = true;

            if (segmentMaterial != null)
            {
                Renderer renderer = segment.GetComponent<Renderer>();
                renderer.material = segmentMaterial;
            }

            Vector3 localPos = new Vector3(0, 0, i * segmentSpacing);
            segment.transform.localPosition = localPos;

            Segments[i] = segment.transform;
            BasePositions[i] = localPos;
        }
    }
}

using UnityEngine;

public class PlayerWorm : MonoBehaviour
{
    public int segmentCount = 10;
    public float segmentSpacing = 0.5f;

    public float waveFrequency = 2f;
    public float waveAmplitude = 0.2f;
    public float waveSpeed = 2f;

    private Transform wormRoot;
    private Transform[] segments;

    private Vector3[] basePositions;
    private Vector3 lastPosition;

    void Start()
    {
        wormRoot = new GameObject("WormBody").transform;
        wormRoot.SetParent(transform);
        wormRoot.localPosition = Vector3.zero;

        segments = new Transform[segmentCount];
        basePositions = new Vector3[segmentCount];

        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            segment.transform.SetParent(wormRoot);
            segment.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 localPos = new Vector3(0, 0, i * segmentSpacing);
            segment.transform.localPosition = localPos;
            basePositions[i] = localPos;
            segments[i] = segment.transform;
        }

        lastPosition = transform.position;
    }

    void Update()
    {
        bool isMoving = (transform.position != lastPosition);

        lastPosition = transform.position;

        AnimateWorm(isMoving);
    }

    void AnimateWorm(bool shouldWriggle)
    {
        for (int i = 0; i < segmentCount; i++)
        {
            Vector3 basePos = basePositions[i];
            float offset = i * 0.5f;
            float y = 0f;
            
            if (shouldWriggle)
            {
                y = Mathf.Sin(Time.time * waveSpeed + offset * waveFrequency) * waveAmplitude;
            }

            segments[i].localPosition = new Vector3(y, 0, basePos.z);
        }
    }
}

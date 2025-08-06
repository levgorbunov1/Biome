using UnityEngine;

[RequireComponent(typeof(WormModelGenerator))]
public class WormAnimator : MonoBehaviour
{
    public float waveFrequency = 2f;
    public float waveAmplitude = 0.2f;
    public float waveSpeed = 2f;

    private WormModelGenerator generator;
    private Vector3 lastPosition;

    void Start()
    {
        generator = GetComponent<WormModelGenerator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        bool isMoving = (transform.position != lastPosition);
        lastPosition = transform.position;

        AnimateWorm(isMoving);
    }

    private void AnimateWorm(bool shouldWriggle)
    {
        if (generator.Segments == null || generator.BasePositions == null)
            return;

        for (int i = 0; i < generator.Segments.Length; i++)
        {
            Vector3 basePos = generator.BasePositions[i];
            float offset = i * 0.5f;

            float y = 0f;
            if (shouldWriggle)
            {
                y = Mathf.Sin(Time.time * waveSpeed + offset * waveFrequency) * waveAmplitude;
            }

            generator.Segments[i].localPosition = new Vector3(y, 0, basePos.z);
        }
    }
}

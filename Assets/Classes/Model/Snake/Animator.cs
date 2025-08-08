using UnityEngine;

[RequireComponent(typeof(WormModelGenerator))]
public class WormAnimator : MonoBehaviour
{
    public float waveFrequency = 2f;
    public float waveAmplitude = 0.2f;
    public float waveSpeed = 2f;

    private WormModelGenerator generator;
    private bool isDead = false;

    void Start()
    {
        generator = GetComponent<WormModelGenerator>();
    }

    void Update()
    {
        if (!isDead) {
            SwimAnimation();
        }
    }

    private void SwimAnimation()
    {
        if (generator.Segments == null || generator.BasePositions == null)
            return;

        for (int i = 0; i < generator.Segments.Length; i++)
        {
            Vector3 basePos = generator.BasePositions[i];
            float offset = i * 0.5f;

            float y = 0f;

            y = Mathf.Sin(Time.time * waveSpeed + offset * waveFrequency) * waveAmplitude;

            generator.Segments[i].localPosition = new Vector3(y, 0, basePos.z);
        }
    }

    public System.Collections.IEnumerator DeathAnimation()
    {
        isDead = true;

        float duration = 1.5f;
        float elapsed = 0f;

        Quaternion initialRotation = generator.WormRoot.localRotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, 90);

        Vector3[] initialPositions = new Vector3[generator.Segments.Length];
        for (int i = 0; i < generator.Segments.Length; i++)
        {
            initialPositions[i] = generator.Segments[i].localPosition;
        }

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, elapsed / duration);

            generator.WormRoot.localRotation = Quaternion.Slerp(initialRotation, targetRotation, t);

            yield return null;
        }

        generator.WormRoot.localRotation = targetRotation;
    }
}

using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public Vector3 rotationOffsetEuler = new Vector3(30f, 0f, 0f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Quaternion rotationOffset = Quaternion.Euler(rotationOffsetEuler);

        Vector3 rotatedOffset = (target.rotation * rotationOffset) * offset;

        Vector3 desiredPosition = target.position + rotatedOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}

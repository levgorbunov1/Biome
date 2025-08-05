using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputActions inputActions;

    public float moveSpeed = 5f;
    public float rotationSpeed = 90f;
    public float maxPitch = 89f;

    private Vector2 screenCenter;

    private void Awake()
    {
        inputActions = new InputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        HandleRotationFromMouse();
        HandleMovement();
    }

    void HandleRotationFromMouse()
    {
        Vector2 mousePos = inputActions.Player.MousePosition.ReadValue<Vector2>();
        Vector2 offsetFromCenter = (mousePos - screenCenter) / screenCenter;

        float yawDelta = offsetFromCenter.x * rotationSpeed * Time.deltaTime;
        float pitchDelta = -offsetFromCenter.y * rotationSpeed * Time.deltaTime;

        Vector3 currentEuler = transform.rotation.eulerAngles;

        float newPitch = currentEuler.x + pitchDelta;
        float newYaw = currentEuler.y + yawDelta;

        // Wrap yaw to avoid overflow
        newYaw = Mathf.Repeat(newYaw, 360f);
        // Clamp pitch to prevent flip
        newPitch = ClampPitch(newPitch);

        transform.rotation = Quaternion.Euler(newPitch, newYaw, 0f);
    }

    float ClampPitch(float pitch)
    {
        if (pitch > 180f) pitch -= 360f;
        return Mathf.Clamp(pitch, -maxPitch, maxPitch);
    }

    void HandleMovement()
    {
        Vector3 moveInput = inputActions.Player.Move.ReadValue<Vector3>();

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.z;

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

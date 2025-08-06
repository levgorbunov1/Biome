using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    private InputActions inputActions;

     private Vector2 screenCenter;

    public float moveSpeed = 5f;
    public float mouseSensitivity = 1.5f;
    public float maxPitch = 89f;
    private float pitch = 0f;  
    private float yaw = 0f;

    private void Awake()
    {
        inputActions = new InputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Vector3 angles = transform.rotation.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        inputActions.Disable();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        HandleRotationFromMouse();
        HandleMovement();
    }

    void HandleRotationFromMouse()
    {
        Vector2 mouseDelta = inputActions.Player.MouseDelta.ReadValue<Vector2>();

        float yawDelta = mouseDelta.x * mouseSensitivity;
        float pitchDelta = -mouseDelta.y * mouseSensitivity;

        yaw += yawDelta;
        pitch += pitchDelta;

        pitch = Mathf.Clamp(pitch, -maxPitch, maxPitch);
        yaw = Mathf.Repeat(yaw, 360f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }


    void HandleMovement()
    {
        Vector3 moveInput = inputActions.Player.Move.ReadValue<Vector3>();
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.z;

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

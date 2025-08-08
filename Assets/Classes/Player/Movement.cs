using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 1.5f;
    public float maxPitch = 89f;

    private InputActions inputActions;
    private Vector2 screenCenter;

    [SerializeField] private Transform playerTransform;

    private float pitch = 0f;  
    private float yaw = 0f;

    private void Awake()
    {
        inputActions = new InputActions();
        playerTransform = transform.parent;
    }

    private void OnEnable()
    {
        inputActions.Enable();

        screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Vector3 angles = playerTransform.rotation.eulerAngles;
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

        playerTransform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }


    void HandleMovement()
    {
        Vector3 moveInput = inputActions.Player.Move.ReadValue<Vector3>();
        Vector3 move = playerTransform.right * moveInput.x + playerTransform.forward * moveInput.z;

        playerTransform.position += move * moveSpeed * Time.deltaTime;
    }
}

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Degrees per second")]
    public float rotationSpeed = 90f;

    [Tooltip("Minimum pitch (looking down) in degrees")]
    public float minPitch = -80f;

    [Tooltip("Maximum pitch (looking up) in degrees")]
    public float maxPitch = 80f;

    // Current rotation state
    private float yaw;
    private float pitch;

    void Start()
    {
        // Initialize from current orientation
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void Update()
    {
        // 1) Read raw input from arrow keys
        float inputX = 0f;
        float inputY = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))  inputX = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) inputX = +1f;
        if (Input.GetKey(KeyCode.UpArrow))    inputY = +1f;
        if (Input.GetKey(KeyCode.DownArrow))  inputY = -1f;

        // 2) Combine into vector and normalize to prevent faster diagonal
        Vector2 input = new Vector2(inputX, inputY);
        if (input.sqrMagnitude > 1f)
            input.Normalize();

        // 3) Apply scaling by speed and time
        float deltaYaw   = input.x * rotationSpeed * Time.deltaTime;
        float deltaPitch = input.y * rotationSpeed * Time.deltaTime;

        // 4) Update yaw and pitch (invert pitch if desired)
        yaw   += deltaYaw;
        pitch -= deltaPitch;  // subtract so UpArrow looks up

        // 5) Clamp pitch to prevent somersaults
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // 6) Apply rotation, keeping roll at zero
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerShipTransform;
    public float cameraDistance = 5f;
    public float minZoomDistance = 2f;
    public float maxZoomDistance = 10f;
    public float rotationSpeed = 5f;
    public float zoomSpeed = 2f;
    public float minAngle = 15f;
    public float maxAngle = 80f;

    private float currentZoomDistance;
    private Vector3 offset;

    void Start()
    {
        // Calculate initial offset based on desired distance
        offset = new Vector3(0f, 0f, -cameraDistance);
        currentZoomDistance = cameraDistance;
    }

    void LateUpdate()
    {
        // Rotate camera around the player while right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            playerShipTransform.Rotate(Vector3.up, mouseX);
        }

        // Adjust camera zoom using scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= scroll * zoomSpeed;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);
        offset.z = -currentZoomDistance;

        // Rotate camera up and down using left mouse button
        if (Input.GetMouseButton(0))
        {
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            float newAngle = transform.eulerAngles.x - mouseY;
            newAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);
            transform.rotation = Quaternion.Euler(newAngle, transform.eulerAngles.y, 0f);
        }

        // Set camera position relative to player
        transform.position = playerShipTransform.position + offset;

        // Make camera look at player
        transform.LookAt(playerShipTransform.position);
    }
}

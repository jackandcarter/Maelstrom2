using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private Rect screenBounds;
    public float wrapBuffer = 0.2f; // Adjust this value as needed

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene!");
            return;
        }

        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
        screenBounds = new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);

        Debug.Log("ScreenWrap initialized for object: " + gameObject.name);
        Debug.Log("Screen bounds: " + screenBounds);
    }

    private void Update()
    {
        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        // Wrap horizontally
        if (transform.position.x < screenBounds.xMin - wrapBuffer)
        {
            newPosition.x = screenBounds.xMax + wrapBuffer;
            DebugConsole.Log("Wrapping horizontally to the right for object: " + gameObject.name, DebugMessageLevel.Info);
        }
        else if (transform.position.x > screenBounds.xMax + wrapBuffer)
        {
            newPosition.x = screenBounds.xMin - wrapBuffer;
            DebugConsole.Log("Wrapping horizontally to the left for object: " + gameObject.name, DebugMessageLevel.Info);
        }

        // Wrap vertically
        if (transform.position.y < screenBounds.yMin - wrapBuffer)
        {
            newPosition.y = screenBounds.yMax + wrapBuffer;
            DebugConsole.Log("Wrapping vertically to the top for object: " + gameObject.name, DebugMessageLevel.Info);
        }
        else if (transform.position.y > screenBounds.yMax + wrapBuffer)
        {
            newPosition.y = screenBounds.yMin - wrapBuffer;
            DebugConsole.Log("Wrapping vertically to the bottom for object: " + gameObject.name, DebugMessageLevel.Info);
        }

        // Apply the new position
        transform.position = newPosition;
    }
}

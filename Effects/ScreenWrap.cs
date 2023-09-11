using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float wrapBuffer = 0.2f; // Adjust this value as needed

    private void Start()
    {
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    private void Update()
    {
        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0 - wrapBuffer)
        {
            // Object moved off the left side of the screen, wrap to the right
            transform.position = mainCamera.ViewportToWorldPoint(new Vector3(1 + wrapBuffer, viewPos.y, viewPos.z));
        }
        else if (viewPos.x > 1 + wrapBuffer)
        {
            // Object moved off the right side of the screen, wrap to the left
            transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0 - wrapBuffer, viewPos.y, viewPos.z));
        }

        if (viewPos.y < 0 - wrapBuffer)
        {
            // Object moved off the bottom of the screen, wrap to the top
            transform.position = mainCamera.ViewportToWorldPoint(new Vector3(viewPos.x, 1 + wrapBuffer, viewPos.z));
        }
        else if (viewPos.y > 1 + wrapBuffer)
        {
            // Object moved off the top of the screen, wrap to the bottom
            transform.position = mainCamera.ViewportToWorldPoint(new Vector3(viewPos.x, 0 - wrapBuffer, viewPos.z));
        }
    }
}

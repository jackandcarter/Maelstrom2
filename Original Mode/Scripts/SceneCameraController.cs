using UnityEngine;

public class SceneCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to the scene loaded event
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This method is called whenever a scene is loaded
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Disable all cameras
        Camera[] cameras = FindObjectsOfType<Camera>();
        foreach (Camera camera in cameras)
        {
            camera.enabled = false;
        }

        // Enable the camera attached to this GameObject
        Camera mainCamera = GetComponent<Camera>();
        if (mainCamera != null)
        {
            mainCamera.enabled = true;
        }
    }

    // OnDestroy is called when the script instance is being destroyed
    void OnDestroy()
    {
        // Unsubscribe from the scene loaded event to prevent memory leaks
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset any state related to the QuitButton script here
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    private void OnDestroy()
    {
        // Ensure to remove the event listener when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

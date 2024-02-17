using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOriginalButton : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset any state related to the PlayOriginalButton script here
    }

    public void OnClick()
    {
        // Load the GameplayScene scene when clicked
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlayScene");
    }

    private void OnDestroy()
    {
        // Ensure to remove the event listener when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

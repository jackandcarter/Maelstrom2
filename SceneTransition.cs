using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName;

    public void LoadTargetScene()
    {
        UnpauseGame(); // Unpause the game before loading the scene
        SceneManager.LoadScene(targetSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f; // Set time scale to normal speed (unpause)
    }
}

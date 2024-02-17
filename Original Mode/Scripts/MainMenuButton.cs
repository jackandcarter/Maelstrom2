using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // Function to return to the main menu.
    public void ReturnToMainMenu()
    {
        // Unload the current scene before loading the main menu scene.
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

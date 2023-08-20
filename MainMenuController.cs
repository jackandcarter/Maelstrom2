using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void EnterMaelstrom()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void OpenSettings()
    {
        // Implement settings panel activation here
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

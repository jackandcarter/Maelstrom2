using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowSettingsPanel()
    {
        // Implement the logic to show the Settings Panel here
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

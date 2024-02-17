using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public GameObject settingsPanel;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the settings panel state
        settingsPanel.SetActive(false);
    }

    public void OnClick()
    {
        // Activate the settings UI panel when clicked
        settingsPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        // Ensure to remove the event listener when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

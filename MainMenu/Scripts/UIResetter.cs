using UnityEngine;
using UnityEngine.UI;

public class UIResetter : MonoBehaviour
{
    // Reference to the UI elements that need to be reset
    public GameObject[] uiElements;

    void Start()
    {
        // Call the ResetUIElements function when the scene is loaded
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Reset UI elements when the scene is loaded
        ResetUIElements();
    }

    void ResetUIElements()
    {
        // Iterate through each UI element and reset its state
        foreach (GameObject uiElement in uiElements)
        {
            // Deactivate and then reactivate the UI element to reset its state
            uiElement.SetActive(false);
            uiElement.SetActive(true);

            // You can add more specific reset logic here if needed
        }
    }
}

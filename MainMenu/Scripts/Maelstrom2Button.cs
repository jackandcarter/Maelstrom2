using UnityEngine;
using UnityEngine.SceneManagement;

public class Maelstrom2Button : MonoBehaviour
{
    public GameObject maelstrom2StartPanel;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Initially deactivate the Maelstrom2Start Panel
        maelstrom2StartPanel.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the Maelstrom2Start Panel state
        maelstrom2StartPanel.SetActive(false);
    }

    public void OnClick()
    {
        // Activate the Maelstrom2Start Panel when clicked
        maelstrom2StartPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        // Ensure to remove the event listener when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

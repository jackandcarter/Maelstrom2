using UnityEngine;
using UnityEngine.SceneManagement;

public class Maelstrom2StartButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Load the MainScene
        SceneManager.LoadScene("MainScene");
    }
}

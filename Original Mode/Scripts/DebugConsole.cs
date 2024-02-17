using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public enum DebugMessageLevel
{
    Info,
    Warning,
    Error
}

public class DebugConsole : MonoBehaviour
{
    private static DebugConsole instance;

    public RectTransform consolePanel; // Reference to the console panel for resizing
    public Text consoleText;
    public Button clearLogButton;

    private List<string> debugMessages = new List<string>();
    public int maxMessages = 100; // Maximum number of messages to keep

    private void Awake()
    {
        instance = this;

        if (clearLogButton != null)
        {
            clearLogButton.onClick.AddListener(ClearLog);
        }

        if (consolePanel != null)
        {
            // Add event listeners for resizing the console panel
            consolePanel.gameObject.AddComponent<ResizeListener>();
        }

        // Initially hide the console
        ToggleConsoleVisibility(false);
    }

    private void Update()
    {
        // Toggle console visibility when / key is pressed
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            ToggleConsoleVisibility(!consolePanel.gameObject.activeSelf);
        }
    }

    public static void Log(string message, DebugMessageLevel level = DebugMessageLevel.Info)
    {
        if (instance != null && instance.consoleText != null)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string formattedMessage = "[" + timestamp + "] " + message;

            if (level == DebugMessageLevel.Warning)
            {
                formattedMessage = "<color=yellow>" + formattedMessage + "</color>";
            }
            else if (level == DebugMessageLevel.Error)
            {
                formattedMessage = "<color=red>" + formattedMessage + "</color>";
            }

            // Add the formatted message to the debugMessages list
            instance.debugMessages.Add(formattedMessage);

            // Remove old messages if exceeding max capacity
            if (instance.debugMessages.Count > instance.maxMessages)
            {
                instance.debugMessages.RemoveRange(0, instance.debugMessages.Count - instance.maxMessages);
            }

            // Update the console text
            instance.UpdateConsoleText();
        }
    }

    private void ClearLog()
    {
        debugMessages.Clear();
        consoleText.text = "";
    }

    private void UpdateConsoleText()
    {
        // Update the console text by joining all debug messages with new lines
        consoleText.text = string.Join("\n", debugMessages);
    }

    public void ToggleConsoleVisibility(bool visible)
    {
        consolePanel.gameObject.SetActive(visible);
    }
}

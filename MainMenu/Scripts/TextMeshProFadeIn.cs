using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextMeshProButtonFadeIn : MonoBehaviour
{
    public float fadeInTime = 1f;
    public float fadeDelay = 0f;

    private Button button;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found.");
            return;
        }

        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshProUGUI component not found as a child of the button.");
            return;
        }

        Color textColor = textMeshPro.color;
        textColor.a = 0f; // Ensure the text is initially transparent
        textMeshPro.color = textColor;

        LeanTween.alphaText(textMeshPro.rectTransform, 1f, fadeInTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setDelay(fadeDelay)
            .setOnComplete(() => Debug.Log("TextMeshPro button fade in complete")); // Optional callback when fade in is complete
    }
}

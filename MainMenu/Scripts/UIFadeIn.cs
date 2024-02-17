using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIFadeIn : MonoBehaviour
{
    public RawImage imageToFade;
    public float fadeInTime = 1f;
    public float fadeDelay = 0f;

    private bool isSceneLoaded = false;

    void Start()
    {
        imageToFade.color = new Color(imageToFade.color.r, imageToFade.color.g, imageToFade.color.b, 0f); // Ensure the image is initially transparent
        StartCoroutine(FadeInWithDelay());

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator FadeInWithDelay()
    {
        yield return new WaitForSeconds(fadeDelay);

        LeanTween.alpha(imageToFade.rectTransform, 1f, fadeInTime)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => Debug.Log("Splash screen fade in complete")); // Optional callback when fade in is complete
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (isSceneLoaded)
        {
            StartCoroutine(FadeInWithDelay());
        }
        else
        {
            isSceneLoaded = true;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

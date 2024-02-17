using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpaceEnvironmentManager : MonoBehaviour
{
    [System.Serializable]
    public class SpaceEnvironment
    {
        public Sprite backgroundSprite;
        public float transitionChance;
        public ParticleSystem layeringEffect;
    }

    public Image backgroundImage;
    public float transitionDuration = 5f;
    public float parallaxSpeed = 0.5f;

    public SpaceEnvironment[] spaceEnvironments;

    private Coroutine transitionCoroutine;

    void Start()
    {
        // Start the initial background transition loop.
        transitionCoroutine = StartCoroutine(BackgroundTransitionLoop());
    }

    IEnumerator BackgroundTransitionLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(transitionDuration);

            // Randomly determine if we should transition to a new environment.
            if (ShouldTransition())
            {
                // Transition to a new environment.
                StartCoroutine(TransitionToNextEnvironment());
            }
        }
    }

    bool ShouldTransition()
    {
        float randomValue = Random.value;
        float cumulativeChance = 0f;

        foreach (var environment in spaceEnvironments)
        {
            cumulativeChance += environment.transitionChance;
            if (randomValue <= cumulativeChance)
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator TransitionToNextEnvironment()
    {
        float startTime = Time.time;
        float endTime = startTime + transitionDuration;

        // Get the current background sprite and create a new sprite for the transition.
        Sprite currentSprite = backgroundImage.sprite;
        Sprite nextSprite = ChooseRandomEnvironment().backgroundSprite;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / transitionDuration;

            // Smoothly fade out the current environment.
            backgroundImage.color = Color.Lerp(Color.white, Color.clear, t);

            // Move the background elements with parallax effect.
            float parallaxOffset = (t * parallaxSpeed) % 1f;
            backgroundImage.material.mainTextureOffset = new Vector2(parallaxOffset, 0f);

            yield return null;
        }

        // Switch to the next space environment.
        SwitchToNextEnvironment(nextSprite);

        // Reset the alpha to fully opaque for the next transition.
        backgroundImage.color = Color.white;
        backgroundImage.material.mainTextureOffset = Vector2.zero;
    }

    void SwitchToNextEnvironment(Sprite nextSprite)
    {
        // Update the background image and layering effect.
        backgroundImage.sprite = nextSprite;

        // Stop and clear the previous layering effect.
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }

        // Play the new layering effect.
        transitionCoroutine = StartCoroutine(PlayLayeringEffect(ChooseRandomEnvironment().layeringEffect));
    }

    SpaceEnvironment ChooseRandomEnvironment()
    {
        float totalChances = 0f;

        foreach (var environment in spaceEnvironments)
        {
            totalChances += environment.transitionChance;
        }

        float randomValue = Random.value * totalChances;

        foreach (var environment in spaceEnvironments)
        {
            if (randomValue <= environment.transitionChance)
            {
                return environment;
            }

            randomValue -= environment.transitionChance;
        }

        // Return the last environment in case of any rounding errors.
        return spaceEnvironments[spaceEnvironments.Length - 1];
    }

    IEnumerator PlayLayeringEffect(ParticleSystem layeringEffect)
    {
        // Play the new layering effect.
        if (layeringEffect != null)
        {
            layeringEffect.Play();
            yield return new WaitForSeconds(layeringEffect.main.duration);
            layeringEffect.Stop();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedAudioPlay : MonoBehaviour
{
    public AudioClip audioClip;
    public float delay = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Create an AudioSource component if it doesn't exist
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Set the audio clip
        audioSource.clip = audioClip;

        // Start playing the audio clip after the delay
        Invoke("PlayAudio", delay);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset the audio source and stop any playing audio
        if (audioSource != null)
        {
            audioSource.Stop();
            Destroy(audioSource);
        }

        // Remove the invocation to prevent multiple audio playbacks
        CancelInvoke();
    }

    private void PlayAudio()
    {
        // Play the audio clip
        audioSource.Play();

        // Stop the audio after it finishes playing
        Destroy(gameObject, audioClip.length);
    }

    private void OnDestroy()
    {
        // Ensure to remove the event listener when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

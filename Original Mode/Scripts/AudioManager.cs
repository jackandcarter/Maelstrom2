using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioClip playerExplosionSound;
    public AudioClip powerUpAppearanceSound;
    public AudioClip powerUpCollectionSound;
    public AudioClip powerUpDestroyedSound;
    public AudioClip enemyCraftSound;
    public AudioClip playerBulletSound;
    public AudioClip enemyBulletSound;
    public AudioClip levelWinSound;
    public AudioClip asteroidExplosionSound;
    public AudioClip saveMeEventSound;
    public AudioClip superNovaEventSound;
    public AudioClip blackHoleEventSound;
    public AudioClip spaceJunkSound;
    public AudioClip cometAppearanceSound;
    public AudioClip pulsarAlarmSound;
    public AudioClip pulsarBuildupSound;
    public AudioClip pulsarExplosionSound;
    public AudioClip ETCraftDeathSound;
    public AudioClip superNovaSound;
   

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip audioClip)
    {
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
        else
        {
            Debug.LogWarning("Trying to play null audio clip.");
        }
    }

    // You can add more audio-related methods and functionality as needed.
}

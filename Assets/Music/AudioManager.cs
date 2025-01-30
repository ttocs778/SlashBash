using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;  // Singleton instance
    private AudioSource audioSource;  // Reference to the AudioSource component

    private void Awake()
    {
        // Check if an instance already exists and destroy the new one if it does
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist AudioManager across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate AudioManager instances
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Ensure the music starts playing if it's not already
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Optional: Method to change the music clip dynamically
    public void ChangeMusic(AudioClip newClip)
    {
        audioSource.Stop();
        audioSource.clip = newClip;
        audioSource.Play();
    }
}

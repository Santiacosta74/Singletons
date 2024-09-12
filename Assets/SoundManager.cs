using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip victoryClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "shoot":
                audioSource.PlayOneShot(shootClip);
                break;
            case "victory":
                audioSource.PlayOneShot(victoryClip);
                break;
        }
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}

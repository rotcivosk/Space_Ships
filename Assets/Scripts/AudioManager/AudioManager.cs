using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource soundEffectsSource;
    [SerializeField] private AudioClip enemyDeathClip;
    [SerializeField] private AudioClip enemyEyeDeathClip;
    [SerializeField] private AudioClip playerDeathClip;
    [SerializeField] private AudioClip shotClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistente entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEnemyDeathSound()
    {
        soundEffectsSource.PlayOneShot(enemyDeathClip);
    }
    public void PlayEnemyEyeDeathSound()
    {
        soundEffectsSource.PlayOneShot(enemyEyeDeathClip);
    }
    public void PlayPlayerDeathSound()
    {
        soundEffectsSource.PlayOneShot(playerDeathClip);
    }

    public void PlayShotSound()
    {
        soundEffectsSource.PlayOneShot(shotClip);
    }
}
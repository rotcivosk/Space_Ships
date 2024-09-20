using System.Collections;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Coroutine to handle the particle system
    public void PlayParticlesAndReturn(GameObject particles, ParticleSystem particleSystem)
    {
        StartCoroutine(ReturnParticlesAfterPlay(particles, particleSystem));
    }

    private IEnumerator ReturnParticlesAfterPlay(GameObject particles, ParticleSystem particleSystem)
    {
        // Wait until the particle system has finished playing
        while (particleSystem != null && particleSystem.isPlaying)
        {
            yield return null;
        }

        // Return particles to the pool after playing
        ParticlePool.Instance.ReturnObject(particles);
    }
}

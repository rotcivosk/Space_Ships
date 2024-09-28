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


    public void PlayParticlesAndReturn(GameObject particles, ParticleSystem particleSystem)
    {
        StartCoroutine(ReturnParticlesAfterPlay(particles, particleSystem));
    }


    public void PlayBossParticlesAndReturn(ParticleSystem particleSystem)
    {
        StartCoroutine(ReturnBossParticlesAfterPlay(particleSystem));
    }


    private IEnumerator ReturnParticlesAfterPlay(GameObject particles, ParticleSystem particleSystem)
    {
        while (particleSystem != null && particleSystem.isPlaying)
        {
            yield return null;
        }

 
        ParticlePool.Instance.ReturnObject(particles);
    }


    private IEnumerator ReturnBossParticlesAfterPlay(ParticleSystem particleSystem)
    {

        while (particleSystem != null && particleSystem.isPlaying)
        {
            yield return null;
        }

        if (particleSystem != null)
        {
            particleSystem.gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject endLevelMenuUI;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerDying();



    }

    private void PlayerDying(){

        

        AudioManager.Instance.PlayPlayerDeathSound();
        GameObject particles = ParticlePool.Instance.GetObject();
        
        particles.transform.position = this.transform.position;
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        player.SetActive(false);
        ParticleManager.Instance.PlayParticlesAndReturn(particles, particleSystem);
        // Wait 2 seconds here
        Invoke("ShowEndLevelMenu", 0.5f);

    }
    private void ShowEndLevelMenu()
    {
        endLevelMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}

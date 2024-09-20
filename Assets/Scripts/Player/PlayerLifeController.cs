using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player; 
    [SerializeField] private GameObject endLevelMenuUI; // Reference to the End Level Menu UI

    private bool isDead = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        PlayerDying();

        isDead = true;


    }


    private void PlayerDying(){

        endLevelMenuUI.SetActive(true);
        Time.timeScale = 0f;

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
        GameController.Instance.GameOver();
    }
}

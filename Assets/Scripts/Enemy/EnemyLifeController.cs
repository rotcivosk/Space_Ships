using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy  : MonoBehaviour
{
    [SerializeField] float health = 5.0f;
    [SerializeField] private float lifeTime = 5f;
    private float spawnTime;


    void Update()
    {       
        if(Time.time - spawnTime >= lifeTime) {
            DieState();
        }
    }
    public void TakeHit(float hitPoints){

        health -= hitPoints;

        if (health < 0){
            DieState();
        }
        

    }

    void OnEnable()
    {
        
        spawnTime = Time.time;

        health = 100f;

        // Reset movement scripts if necessary
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.ResetMovement();
        }
    }
    void DieState()
    {

        startSoundEffect();
        GameController.Instance.AddScore(10);
        

        GameObject particles = ParticlePool.Instance.GetObject();
        particles.transform.position = this.transform.position;
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        EnemyPool.Instance.ReturnObject(gameObject);
        ParticleManager.Instance.PlayParticlesAndReturn(particles, particleSystem);
    }

    private void startSoundEffect(){
        if (gameObject.tag == "Enemy"){
        AudioManager.Instance.PlayEnemyDeathSound();
        }
        if (gameObject.tag == "Enemy2"){
        AudioManager.Instance.PlayEnemyEyeDeathSound();
        }
    }
}

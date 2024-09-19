using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy  : MonoBehaviour
{
    [SerializeField] float health = 5.0f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private GameObject particlePrefab;
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
    void DieState() {
        Debug.Log("Morreu");
        //Instantiate(particlePrefab, this.transform.position, Quaternion.identity);
        //Destroy(particlePrefab, 3f);
        //particles.Play();
        EnemyPool.Instance.ReturnObject(gameObject);
    }
}

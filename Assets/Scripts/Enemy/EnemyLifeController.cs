using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy  : MonoBehaviour
{
    [SerializeField] float health = 5.0f;


    void Update()
    {
        
    }
    public void TakeHit(float hitPoints){

        health -= hitPoints;

        if (health < 0){
            DieState();
        }

    }

    void OnEnable()
    {
        // Reset health or other properties
        health = 100f;

        // Reset movement scripts if necessary
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.ResetMovement();
        }
    }
    void DieState(){
        EnemyPool.Instance.ReturnObject(gameObject);
    }
}

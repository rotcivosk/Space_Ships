using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeController : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 5.0f;
    private float currentHitPoints;
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }
    void Update()
    {
        
    }
    public void TakeHit(float hitPoints){

        currentHitPoints = currentHitPoints - hitPoints;
        Debug.Log("Take hit" + hitPoints+ " New life:" +  currentHitPoints);
        if (currentHitPoints < 0){
            DieState();
        }

    }


    void DieState(){
        Destroy(gameObject);
    }
}

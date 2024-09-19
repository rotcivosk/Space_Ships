using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool
{
    public static EnemyPool Instance;

    protected override void Awake() {
        if (Instance  == null){
            Instance = this;
            // Call the base class Awake method to initialize the pool
            base.Awake();

        } else{
            Destroy(gameObject);
        }
    }
}

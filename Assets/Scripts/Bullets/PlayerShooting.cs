using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float bulletSpawnDistance = 3.0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
    {
        
        FireBullet();
    }
    }

    void FireBullet(){
        AudioManager.Instance.PlayShotSound();
        GameObject bullet = BulletPool.Instance.GetObject();
        Vector3 spawnPosition = transform.position + transform.right * bulletSpawnDistance; 
        
        bullet.transform.position = spawnPosition;
        bullet.transform.rotation = transform.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}

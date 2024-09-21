using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private float bulletDamage = 100.0f;
    private float spawnTime;
    
    void OnEnable() {
        spawnTime = Time.time;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(Time.time - spawnTime >= lifeTime) {
            BulletPool.Instance.ReturnObject(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        if (collision.tag == "Enemy"|| collision.tag == "Enemy2"){
            //Debug.Log("Identificou Inimigo");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeHit(bulletDamage);
            //collision.gameObject.SendMessage("TakeHit", 1.0);
        }
        if (collision.tag == "Boss"){
        BossController boss = collision.gameObject.GetComponentInParent<BossController>();

        if (boss != null)
        {
            boss.TakeDamageBoss(bulletDamage);
        }
        else
        {
            Debug.LogError("BossController not found on the Boss GameObject.");
        }
        }
        BulletPool.Instance.ReturnObject(gameObject);
    }

}

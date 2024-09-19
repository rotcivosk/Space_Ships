using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProjectile : MonoBehaviour
{

    
    [SerializeField]    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision){

        if (collision.tag == "Enemy"){
            Debug.Log("Identificou Inimigo");

            EnemyLifeController enemy = collision.gameObject.GetComponent<EnemyLifeController>();
            enemy.TakeHit(1.0f);
        
            //collision.gameObject.SendMessage("TakeHit", 1.0);
        }

    }

}

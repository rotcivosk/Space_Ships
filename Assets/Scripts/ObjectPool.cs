using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();

    protected virtual void Awake() {
        for (int i = 0; i < poolSize; i++){
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }


    public GameObject GetObject(){
        if (pool.Count>0){
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        } else {
            GameObject obj = Instantiate(prefab);
            return obj;
        }
    }

    public void ReturnObject(GameObject obj){
        obj.SetActive(false);
        pool.Enqueue(obj);

    }
}

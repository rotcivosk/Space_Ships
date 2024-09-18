using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    public abstract void Move();
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    public abstract void Move();
    // Update is called once per frame
        public virtual void ResetMovement()
    {
        // Optional: Override in subclasses to reset variables
    }
    void Update()
    {
        Move();
    }
}

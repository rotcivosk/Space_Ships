using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ZigzagMovement : EnemyMovement
{
    [SerializeField] private float amplitude = 1.0f;
    [SerializeField] private float frequency = 1.0f;
    private float time;


    public override void Move()
    {
        time += Time.deltaTime;
        float y = Mathf.Sin(time * frequency) * amplitude;
        Vector2 direction = new Vector2(-1,y).normalized;
        transform.Translate(direction*speed*Time.deltaTime);
    }
}

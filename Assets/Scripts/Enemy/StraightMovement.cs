
using UnityEngine;

public class StraightMovement : EnemyMovement
{
    // Start is called before the first frame update
    public override void Move()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }
}

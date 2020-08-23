
using System.Collections.Generic;
using UnityEngine;

public class SwarmEnemy : Enemy
{
    
    public List<SwarmEnemy> otherEnemies;

    protected override void FixedUpdate()
    {
        Vector2 dir = (target.transform.position - transform.position).normalized;
        if (CheckCollision(dir))
        {
            rb.AddForce(dir * (moveForce * 10));
        }

        for (int i = 0; i < otherEnemies.Count; i++)
        {
            Move((otherEnemies[i].transform.position - transform.position).normalized, 1);
        }
    }

}

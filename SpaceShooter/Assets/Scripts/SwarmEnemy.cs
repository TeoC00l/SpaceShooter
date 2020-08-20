
using System.Collections.Generic;
using UnityEngine;

public class SwarmEnemy : Enemy
{
    
    public List<SwarmEnemy> otherEnemies;

    protected override void FixedUpdate()
    {
        for (int i = 0; i < otherEnemies.Count; i++)
        {
            Move((otherEnemies[i].transform.position - transform.position).normalized, 0.5f);
        }
    }

}

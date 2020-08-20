using  System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySwarmController : MonoBehaviour
{
    [SerializeField]
    private int numberOfEnemies = 1;
    [SerializeField]
    private GameObject enemy;
    private List<SwarmEnemy> enemies = new List<SwarmEnemy>();

    [SerializeField]
    private GameObject target;
    
    private void Awake()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector2 posOffset = Random.insideUnitCircle;
            GameObject gO = Instantiate(enemy, (Vector2)transform.position + posOffset, Quaternion.identity);
            gO.transform.parent = transform;
            SwarmEnemy e = gO.GetComponent<SwarmEnemy>();
            e.otherEnemies = enemies;
            e.target = target;
            enemies.Add(e);
        }
        
        
    }
    
    
}

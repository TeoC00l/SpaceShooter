using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateCave : MonoBehaviour
{
    [SerializeField]
    private GameObject circle;
    [SerializeField]
    private int caveLenght = 10;
    [SerializeField]
    private int minRadius = 1;
    [SerializeField]
    private int maxRadius = 10;

    private void Start()
    {
        Vector2 spawnPos = transform.position;
        for (int i = 0; i < caveLenght; i++)
        {
            float diameter = Random.Range(minRadius, maxRadius);
            spawnPos += new Vector2(diameter / 2 - 1 , 0);
            GameObject c = Instantiate(circle, spawnPos, quaternion.identity);
            c.transform.localScale = new Vector3(diameter, diameter, 0);
            spawnPos += new Vector2(diameter / 2, 0);
        }
    }
}

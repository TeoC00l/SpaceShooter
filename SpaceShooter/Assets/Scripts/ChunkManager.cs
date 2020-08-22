using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

//TODO: is activeChunks Needed?
public class ChunkManager : MonoBehaviour
{
    private int nodeSpawnPercentChance = 50;
    [SerializeField] private float chunkSpeed = 10;
    private Vector2 startPosition = new Vector2(70f, 0f);
    public float ChunkSpeed {set { chunkSpeed = value; } get { return chunkSpeed;  } }
    
    [SerializeField] private GameObject[] chunks;
    [SerializeField] private GameObject[] spawnObjects;

    private Random random = new Random();
    private List<GameObject> activeChunks = new List<GameObject>();
    private GameObject lastChunk;


    void Awake()
    {
        CreateNewChunk();
    }

    public void CreateNewChunk()
    {
        Debug.Log("object spawned");
        GameObject chunk = Instantiate(chunks[Random.Range(0, chunks.Length)]);

        if(lastChunk == null)
        {
            chunk.transform.position = startPosition;
        }
        else
        {
            chunk.transform.position = CalculateSpawnPoint();

        }
        activeChunks.Add(chunk);
        lastChunk = chunk;
        InitializeNodes();
    }

    public void RemoveChunk(GameObject chunk)
    {
        activeChunks.Remove(chunk);
        Destroy(chunk);
    }

    private Vector3 CalculateSpawnPoint()
    {
        Vector3 offset = lastChunk.transform.right * lastChunk.transform.localScale.x;
        Vector3 pos = lastChunk.transform.position + offset;

        return pos;
    }

    private void InitializeNodes()
    {
        //TODO: Object pool?

        GameObject[] nodes = lastChunk.GetComponent<Chunk>().nodes;

        for (int i = 0; i<nodes.Length; i++)
        {
            if (Random.Range(0, 100) < nodeSpawnPercentChance)
            {
                GameObject spawned = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], nodes[i].transform.position, Quaternion.identity);
                spawned.transform.parent = nodes[i].transform;
            }
        }
    }



    
}

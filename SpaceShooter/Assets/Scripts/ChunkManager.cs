using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//TODO: is activeChunks Needed?
public class ChunkManager : MonoBehaviour
{
    [SerializeField]private float chunkSpeed = 10;
    private Vector2 startPosition = new Vector2(70f, 0f);
    public float ChunkSpeed {set { chunkSpeed = value; } get { return chunkSpeed;  } }
    [SerializeField] private GameObject[] chunks;
    private Random random = new Random();
    private List<GameObject> activeChunks = new List<GameObject>();
    private GameObject lastChunk;


    void Awake()
    {
        CreateNewChunk();
    }

    public void CreateNewChunk()
    {
        GameObject chunk = Instantiate(chunks[Random.Range(0, chunks.Length)]);

        if(lastChunk == null)
        {
            chunk.transform.position = startPosition;
        }
        else
        {
            chunk.transform.position = calculateSpawnPoint();

        }
        activeChunks.Add(chunk);
        lastChunk = chunk;
    }

    public void RemoveChunk(GameObject chunk)
    {
        activeChunks.Remove(chunk);
        Destroy(chunk);
    }

    public Vector3 calculateSpawnPoint()
    {
        Vector3 offset = lastChunk.transform.right * lastChunk.transform.localScale.x;
        Vector3 pos = lastChunk.transform.position + offset;

        return pos;
    }
}

using UnityEngine;
using Random = UnityEngine.Random;

public class ChunkManager : MonoBehaviour
{
    private int nodeSpawnPercentChance = 50;
    private Vector2 startPosition = new Vector2(70f, 0f);

    [SerializeField] private float chunkSpeed = 10;
    public float ChunkSpeed {set { chunkSpeed = value; } get { return chunkSpeed;  } }
    
    [SerializeField] private GameObject[] chunks;
    [SerializeField] private GameObject[] spawnObjects;

    private Random random = new Random();
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
            chunk.transform.position = CalculateSpawnPoint();

        }
        lastChunk = chunk;
        InitializeNodes();
    }

    public void RemoveChunk(GameObject chunk)
    {
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

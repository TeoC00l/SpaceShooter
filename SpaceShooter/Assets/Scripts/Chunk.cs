using UnityEngine;

public class Chunk : MonoBehaviour
{
    private ChunkManager chunkManager;
    private float horizontalDestroyCoordinate = -50f;

    void Awake()
    {
        //transform.position = startPosition;
    }

    void Start()
    {
        chunkManager = FindObjectOfType<ChunkManager>();
    }

    void Update()
    {
        transform.position += Vector3.left * chunkManager.ChunkSpeed * Time.deltaTime;

        if( transform.position.x < horizontalDestroyCoordinate)
        {
            chunkManager.RemoveChunk(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera")){
            chunkManager.CreateNewChunk();
        }
    }
}

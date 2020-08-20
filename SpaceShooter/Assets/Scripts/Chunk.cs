using UnityEngine;

public class Chunk : MonoBehaviour
{
    private ChunkManager chunkManager;
    private float movementSpeed = 10;
    private Vector2 startPosition = new Vector2(99.7f, 0f);
    private float horizontalDestroyCoordinate = -50f;

    void Awake()
    {
        transform.position = startPosition;
    }

    void Start()
    {
        chunkManager = FindObjectOfType<ChunkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;

        if( transform.position.x < horizontalDestroyCoordinate)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera")){
            chunkManager.CreateNewChunk();
        }
    }
}

using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    private float movementSpeed;
    [SerializeField] private GameObject[] chunks;
    private Random random = new Random();

    void Awake()
    {

    }

    public void CreateNewChunk()
    {
        GameObject chunk = Instantiate(chunks[Random.Range(0, chunks.Length)]);
    }
}

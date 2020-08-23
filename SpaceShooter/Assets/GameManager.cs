using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float score;
    public GameObject player;
    private ChunkManager chunkManager;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        chunkManager = FindObjectOfType<ChunkManager>();

    }


    // Update is called once per frame
    void Update()
    {
        score += 0.1f;

        if(score % 100 == 0)
        {
            chunkManager.ChunkSpeed += 1;
            Debug.Log("Going faster!");
        }
    }
}

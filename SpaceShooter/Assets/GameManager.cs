using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
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
        score += 1;

        if(score % 20000 == 0)
        {
            Debug.Log("Going faster!");
            chunkManager.ChunkSpeed += 1;
        }
    }
}

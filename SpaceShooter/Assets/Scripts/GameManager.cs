using UnityEngine;
using  UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    private ChunkManager chunkManager;

    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private Text scoreText;
    
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

    public void SaveScore()
    {
        if (PlayerPrefs.GetInt("MaxScore") < score)
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }
    }

    public void DisplayScore()
    {
        scoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        scoreText.text = "High-Score: " + score.ToString();
        highScoreText.text = "Score: " + PlayerPrefs.GetInt("MaxScore").ToString();
    }
}

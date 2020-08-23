using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * parallaxEffect * Time.deltaTime;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("poop");
        if (other.CompareTag("MainCamera"))
        {
            Vector3 offset = transform.right * GetComponent<SpriteRenderer>().bounds.size.x / 2;
            Vector3 pos = transform.position + offset;
            GameObject go = Instantiate(gameObject);
            go.transform.position = pos;
        }
    }
}

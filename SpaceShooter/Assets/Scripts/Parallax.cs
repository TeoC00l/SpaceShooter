using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float size;
    [SerializeField] private float marginal = 0.01f;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -size *2)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.left * parallaxEffect * Time.deltaTime;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Vector3 offset = transform.right * (size - marginal);
            Vector3 pos = transform.position + offset;
            GameObject go = Instantiate(gameObject);
            go.transform.position = pos;
        }
    }
}

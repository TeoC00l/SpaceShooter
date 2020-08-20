using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;

    public void Init(float velocity)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocity;
    }
}

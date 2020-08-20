using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private float bulletLife;
    private float lifeTimer;

    public void Init(float velocity, float life)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocity;
        bulletLife = life;
        lifeTimer = 0;
    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= bulletLife)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);
    }
}

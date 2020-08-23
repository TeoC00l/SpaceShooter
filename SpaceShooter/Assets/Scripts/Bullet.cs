using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private float bulletLife;
    private float lifeTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Init(float velocity, float life)
    {
        rb.velocity = Vector2.right * velocity;
        bulletLife = life;
        lifeTimer = 0;
    }
    
    public void Init(float velocity, float life, Vector2 dir)
    {
        rb.velocity = dir * velocity;
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

        if (other.gameObject.CompareTag("Damageable"))
        {
            other.gameObject.GetComponent<Damageable>().Damage(1);
        }
        gameObject.SetActive(false);
    }
}

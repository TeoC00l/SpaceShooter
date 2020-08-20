using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveForce;
    public GameObject target;

    [SerializeField] private LayerMask colideLayer;

    protected virtual void FixedUpdate()
    {
        Vector2 dir = (target.transform.position - transform.position).normalized;
        Move(dir);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Move(Vector2 dir, float speedMod = 1)
    {
        if (!CheckCollision(dir))
        {
            rb.AddForce(dir * (moveForce * speedMod));
        }
        else
        {
            rb.AddForce(-dir * (moveForce * 2 * speedMod));
        }
    }

    protected virtual bool CheckCollision(Vector2 dir)
    {
        Debug.DrawRay(transform.position, dir);
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, dir, 3, colideLayer);

        return hit.Any(hitObj => hitObj.transform.gameObject != gameObject);
    }
}
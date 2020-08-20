using System;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float verticalForce = 20;
    [SerializeField]
    private float horizontalForce = 20;
    [SerializeField]
    private bool freeMoving;
    private Rigidbody2D rb;
    [NonSerialized]
    public bool thrustUp;
    [NonSerialized]
    public float horizontalBoost;
    [SerializeField]
    private ParticleSystem thrustParticleSystem;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (thrustUp)
        {
            thrustParticleSystem.Emit(1);
            rb.AddForce(Vector2.up * (verticalForce * Time.fixedDeltaTime));
        }

        if (horizontalBoost != 0)
        {
            rb.AddForce(Vector2.right * (Input.GetAxis("Horizontal")* horizontalForce * Time.fixedDeltaTime));
        }

    } 
}

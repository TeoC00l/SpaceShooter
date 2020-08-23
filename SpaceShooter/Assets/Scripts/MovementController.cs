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

    [SerializeField]
    private float tiltModefier = 20;
    
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

        float tilt = rb.velocity.x * tiltModefier  + 10f;

        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -tilt));

        if (horizontalBoost != 0)
        {
            rb.AddForce(Vector2.right * (Input.GetAxis("Horizontal")* horizontalForce * Time.fixedDeltaTime));
        }

    } 
}

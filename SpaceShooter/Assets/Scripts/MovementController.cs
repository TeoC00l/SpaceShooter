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
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletVelocity = 5;
    [SerializeField]
    private float fireRate = 0.1f;
    private float fireRateTimer;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        fireRateTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (fireRateTimer >= fireRate)
            {
                fireRateTimer = 0;
                GameObject b = Instantiate(bulletPrefab, transform.position, quaternion.identity);
                b.GetComponent<Bullet>().Init(bulletVelocity);
            }
        }
    }

    private void Move()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * (verticalForce * Time.deltaTime));
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddForce(Vector2.right * (Input.GetAxis("Horizontal")* horizontalForce * Time.deltaTime));
        }

    } 
}

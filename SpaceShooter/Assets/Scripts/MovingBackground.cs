using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, (Vector2) transform.position + Vector2.left,
            movementSpeed * Time.deltaTime);
        //transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }
}
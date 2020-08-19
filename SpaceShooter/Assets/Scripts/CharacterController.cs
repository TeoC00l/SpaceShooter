using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += Vector3.up * Input.GetAxis("Vertical") * movementSpeed *Time.deltaTime;
        }
    }
}

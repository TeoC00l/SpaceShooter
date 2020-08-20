using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerInput : MonoBehaviour
{
    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }
}

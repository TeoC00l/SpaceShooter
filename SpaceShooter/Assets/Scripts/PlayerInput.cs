using System;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerInput : MonoBehaviour
{
    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            movementController.thrustUp = true;
        }
        else
        {
            movementController.thrustUp = false;
        }

        movementController.horizontalBoost = Input.GetAxis("Horizontal");
    }
}

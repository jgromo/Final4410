using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrickTrigger : MonoBehaviour
{
    public WinCondition winConditionController;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player character enters the trigger zone of the cube
        if (other.CompareTag("Player"))
        {
            PickupControllerv2 pickupController = other.GetComponent<PickupControllerv2>();

            // Check if the player is holding an object
            if (pickupController != null && pickupController.HeldObject != null)
            {
                // Player is on top of the cube and is holding an object
                // Declare the player as the winner
                winConditionController.OnTriggerBrick(gameObject);
            }
        }
    }
}

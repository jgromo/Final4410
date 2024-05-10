using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private Animator animator;
    private GameObject heldObject;
    private Transform hand;

    public GameObject HeldObject
    {
        get { return heldObject; }
        set { heldObject = value; }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        hand = transform.Find("Hand"); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && heldObject == null)
        {
            // Check if there's an object in range to pick up
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f); 
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Pickup"))
                {
                    // Pick up the object
                    heldObject = collider.gameObject;
                    heldObject.transform.SetParent(hand);
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.transform.localRotation = Quaternion.identity;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && heldObject != null)
        {
            // Release the held object
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }
}

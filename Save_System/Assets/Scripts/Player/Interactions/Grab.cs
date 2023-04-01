using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectHolderTransform;
    [SerializeField] private float pickupDistance;

    private Grabbable grabbableObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabbableObject == null)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out grabbableObject))
                    {
                        grabbableObject.Grab(objectHolderTransform); // Calls the Grab() function for the grabbable object to set its position in the object holder position.
                    }
                }
            }
            else
            {
                grabbableObject.Throw(); // Calls the Throw() funtion to throw the object.
                grabbableObject = null; // There is no grabbable object anymore.
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    public LayerMask interactableLayer; // Layer of interactable objects.
    public string interactButton = "Mouse0"; // Button to interact with objects.

    void Update()
    {
        // Check if interact button is pressed.
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the camera is looking at an object in the interactable layer.
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, interactableLayer.value))
            {
                hit.collider.gameObject.SetActive(false); // Deactivate the object.
            }
        }
    }
}   

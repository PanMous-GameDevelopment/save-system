using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public float throwForce = 10f;

    private Rigidbody objectRigidbody;
    private Transform objectHolderTransform;
    private Vector3 throwDirection;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectHolderTransform) // Grabs the object and puts it in the object holder position.
    {
        this.objectHolderTransform = objectHolderTransform; 
        objectRigidbody.useGravity = false; // Deactivates gravity.
    }

    public void Throw() // Throws the object away.
    {
        objectHolderTransform = null; // The object holder becomes null.
        objectRigidbody.useGravity = true; // Activate gravity.

        // Calculates throw direction at the opposite direction of where the camera looks.
        throwDirection = Camera.main.transform.forward * 1f;

        // Apply force to the object in the calculated direction.
        objectRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (objectHolderTransform != null) // If an object exists in the object holder.
        {
            float lerpSpeed = 10f;
            Vector3 holdingPosition = Vector3.Lerp(transform.position, objectHolderTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(holdingPosition);
        }
    }
}

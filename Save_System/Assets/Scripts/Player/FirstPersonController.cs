using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;
    [SerializeField] private float lookXLimit = 60.0f;
    [SerializeField] private float gravity = -9.81f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private CharacterController characterController;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = Vector3.ClampMagnitude(movement, 1f); // Prevent faster diagonal movement
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed * Time.deltaTime;

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        movement += velocity * Time.deltaTime;

        characterController.Move(movement);

        // Rotation
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY += Input.GetAxis("Mouse X") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }
}

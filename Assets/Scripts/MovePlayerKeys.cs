using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayerKeys : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // Get the horizontal input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        // Get the vertical input for movement
        float verticalInput = Input.GetAxis("Vertical");

        // Move the player forward/backward and sideways
        Vector3 movement = transform.forward * verticalInput;
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Get the horizontal input for rotation
        float rotationInput = Input.GetAxis("Horizontal");
        // Rotate the player around the Y-axis
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}
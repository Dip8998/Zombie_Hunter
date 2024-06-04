using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Player's transform
    public Vector3 offset; // Offset from the player
    public float followSpeed = 10f; // Speed at which the camera follows the player
    public float rotationSpeed = 5f; // Speed of camera rotation
    public float zoomSpeed = 5f; // Speed of zooming

    private float currentZoom = 0f; // Current zoom level
    public float minZoom = -5f; // Minimum zoom distance
    public float maxZoom = -15f; // Maximum zoom distance

    private void LateUpdate()
    {
        // Follow the player smoothly
        Vector3 targetPosition = target.position + offset + (Vector3.forward * currentZoom);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Rotate the camera around the player
        if (Input.GetMouseButton(1)) // Right mouse button for rotation
        {
            float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
            target.Rotate(0, horizontalInput, 0);
        }

        // Zoom the camera in and out
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        if (zoomInput != 0f)
        {
            currentZoom -= zoomInput * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        }
    }
}

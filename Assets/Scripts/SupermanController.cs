using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermanController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float flySpeed = 10f;
    public float jumpForce = 10f;
    public float gravity = -20f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (isGrounded)
        {
            // Ground movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;
            controller.Move(move * moveSpeed * Time.deltaTime);

            // Jumping
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }

        // Apply gravity
        moveDirection.y += gravity * Time.deltaTime;

        // Flying
        if (Input.GetKey(KeyCode.F))
        {
            moveDirection.y = flySpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}

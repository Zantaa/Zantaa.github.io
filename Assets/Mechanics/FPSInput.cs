using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    private CharacterController characterController;

    [SerializeField]
    private float speed = 6.0f;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private float jumpHeight = 3f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movementDirection = transform.right * deltaX + transform.forward * deltaZ;

        characterController.Move(movementDirection * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }//end update
}

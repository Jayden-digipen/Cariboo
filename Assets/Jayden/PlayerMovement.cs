using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform playerCapsule;
    public float movementSpeed;

    public Transform orientationPlayerCameraDirection;
    Transform playerTransform;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [SerializeField] Vector3 velocityCheck;

    


    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        playerCapsule.transform.rotation = orientationPlayerCameraDirection.transform.rotation;
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
       
        moveDirection = orientationPlayerCameraDirection.forward * verticalInput + orientationPlayerCameraDirection.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * movementSpeed * 4f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        velocityCheck = flatVelocity;
        
        if (flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}

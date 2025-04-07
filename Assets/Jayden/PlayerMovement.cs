using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    StaminaUI staminaUI;
    [SerializeField] Transform playerCapsule;
    
    [SerializeField] private float currentSpeed = 4.5f;
    public float walkingSpeed = 4.5f;
    public float runningSpeed = 10f;


    [SerializeField] private float currentAccelerator = 5f;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [SerializeField] private float Stamina = 100f;
    [SerializeField] private float StaminaDecreaser = 1f;
    [SerializeField] private float StaminaIncreaser = 0.2f;
    private float staminaCountdown = 20;
    

    public Transform orientationPlayerCameraDirection;
    Transform playerTransform;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    

    public MovementState state;
    public enum MovementState
    {
        walking,
        running
    }

    private void Start()
    {      
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        playerCapsule.transform.rotation = orientationPlayerCameraDirection.transform.rotation;
        MyInput();
        WalkingRunning();
        StateHandler();
       
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

    private void StateHandler()
    {
         
        if (Input.GetKey(sprintKey) & Stamina > 0 & staminaCountdown <= 0)
        {
            state = MovementState.running;
            currentSpeed = runningSpeed;
            staminaCountdown = 20f;
            Stamina -= StaminaDecreaser;
            staminaUI.StaminaBar.fillAmount = Stamina/100;

        }

        else
        {
            state = MovementState.walking;
            currentSpeed = walkingSpeed;
            staminaCountdown -= Time.deltaTime;
            
            if(Stamina <= 100)
            {
                Stamina += StaminaIncreaser;
            }
            staminaUI.StaminaBar.fillAmount = Stamina/100;
        }
    }



    private void MovePlayer()
    {    
        moveDirection = orientationPlayerCameraDirection.forward * verticalInput + orientationPlayerCameraDirection.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * currentSpeed * currentAccelerator, ForceMode.Force);
    }

    private void WalkingRunning()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        Debug.Log(flatVelocity.magnitude);
        
        if (flatVelocity.magnitude >= currentSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * walkingSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }        
    }

   
   
}

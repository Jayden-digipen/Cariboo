using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts")]
    StaminaUI staminaUI;

    [Header("Player Transforms")]
    public float playerHeight;

    [SerializeField] Transform playerCapsule;
    Transform playerTransform;

    [Header("Speed of the player")]
    [SerializeField] private float currentSpeed;
    public float walkingSpeed = 4.5f;
    public float runningSpeed = 10f;
    public float crouchSpeed = 3f;
    public float crouchYScale;
    private float crouchYStart;
    [SerializeField] private float currentAccelerator = 5f;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    
    

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Stamina")]
    [SerializeField] private float Stamina = 100f;
    [SerializeField] private float StaminaDecreaser = 1f;
    [SerializeField] private float StaminaIncreaser = 0.2f;
    float originalCountdown;
    bool restartCountdown = false;


    [Header("Other")]
    
    public Transform orientationPlayerCameraDirection;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    bool grounded = true;

    [SerializeField] AudioSource walkingAudioSource;
   [SerializeField] AudioSource FootstepAudioSource;
   

    public MovementState state;
    public enum MovementState
    {
        walking,
        running,
        crouch,
        air
        
    }

    private void Start()
    {
        crouchYStart = transform.localScale.y;
        staminaUI = FindObjectOfType<StaminaUI>();
        originalCountdown = staminaUI.staminaCountdown;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        
        playerCapsule.transform.rotation = orientationPlayerCameraDirection.transform.rotation;
        MyInput();
        StateHandler();
        WalkingRunning();

       
    }

   

    private void FixedUpdate()
    {    
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYStart, transform.localScale.z);
        }
    }

    private void StateHandler()
    {

        if (Input.GetKey(crouchKey))
        {
            
            state = MovementState.crouch;
            currentSpeed = crouchSpeed;
        }

        else if (Input.GetKey(sprintKey) & Stamina > 0)
        {

            state = MovementState.running;
           
            currentSpeed = runningSpeed;
           
            Stamina -= StaminaDecreaser;
            staminaUI.StaminaBar.fillAmount = Stamina / 100;
            restartCountdown = true;

        }

        else if(grounded)
        {
            
            state = MovementState.walking;
            currentSpeed = walkingSpeed;
            FootstepAudioSource.Play();




            if (restartCountdown)
            {
                staminaUI.staminaCountdown = originalCountdown;
                restartCountdown = false;
            }
     
            if (Stamina <= 100)
            {
                staminaUI.staminaCountdown -= Time.deltaTime;
                if (staminaUI.staminaCountdown <= 0)
                {
                    Stamina += StaminaIncreaser;
                }
            }

            staminaUI.StaminaBar.fillAmount = Stamina / 100;
        }

        else
        {
            state = MovementState.air;
        }



    }



    private void MovePlayer()
    {    
        moveDirection = orientationPlayerCameraDirection.forward * verticalInput + orientationPlayerCameraDirection.right * horizontalInput;

        if (OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * currentSpeed * 20f, ForceMode.Force);

            if(rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 100f, ForceMode.Force);
            }
        }
        rb.AddForce(moveDirection.normalized * currentSpeed * currentAccelerator, ForceMode.Force);
        rb.useGravity = !OnSlope();
    }

    private void WalkingRunning()
    {
        if (OnSlope())
        {
            if(rb.velocity.magnitude > currentSpeed)
            {
                rb.velocity = rb.velocity.normalized;
            }
        }


        else
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);


            if (flatVelocity.magnitude >= currentSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * walkingSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }
        }
        
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight *0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    
    
}

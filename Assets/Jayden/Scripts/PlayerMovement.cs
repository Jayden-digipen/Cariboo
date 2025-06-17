 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts")]
    StaminaUI staminaUI;

    [Header("Player Transforms")]

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

    [Header("Ground Check")]
    public LayerMask isGrounded;
    bool grounded;
    public float playerHeight;
    [SerializeField] float groundDrag;

    [Header("Sound effects")]
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip[] moveClip;
   

    private float footstepTimer = 0f;
    private float footstepInterval = 0.5f;

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
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isGrounded);
        Debug.Log(OnSlope());
       
        playerCapsule.transform.rotation = orientationPlayerCameraDirection.transform.rotation;
        MyInput();
        StateHandler();
        SpeedControl();
        PlayFootstepSounds();


        if (state == MovementState.crouch)
        {
            rb.drag = groundDrag;
        }
            
        else
            rb.drag = 0;

    }

    private AudioClip GetRandomClip(AudioClip[] clips)
    {
        if (clips.Length == 0) return null;
        return clips[Random.Range(0, clips.Length)];
    }


    private void PlayFootstepSounds()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        bool isMoving = horizontalInput != 0 || verticalInput != 0;


        if (!grounded || !isMoving)
        {
            footstepTimer = 0f;
            return;
        }

        AudioClip selectedClip = null;

        if (state == MovementState.walking)
        {
            footstepInterval = 0.5f;
            selectedClip = GetRandomClip(moveClip);
           
                
        }
        else if (state == MovementState.running)
        {
            footstepInterval = 0.3f;
            selectedClip = GetRandomClip(moveClip);


        }
        else if (state == MovementState.crouch)
        {
            footstepInterval = 0.8f;
            selectedClip = GetRandomClip(moveClip);


        }
        else
        {
            return; 
        }

        // Timer playback
        footstepTimer -= Time.deltaTime;
        if (footstepTimer <= 0f && selectedClip != null)
        {
            footstepAudioSource.PlayOneShot(selectedClip);
            footstepTimer = footstepInterval;
        }
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

        else if (Input.GetKey(sprintKey) & Stamina > 0 && grounded)
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
            rb.AddForce(GetSlopeMoveDirection() * currentSpeed * 100f, ForceMode.Force);

            if(rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        else  if (grounded)
        {
            rb.AddForce(moveDirection.normalized * currentSpeed * currentAccelerator, ForceMode.Force);
        }

      

        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        if (OnSlope())
        {
            if (rb.velocity.magnitude > currentSpeed)
                rb.velocity = rb.velocity.normalized * currentSpeed;
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
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
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

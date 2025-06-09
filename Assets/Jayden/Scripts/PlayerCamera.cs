using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Enemy")]
    public Transform target;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyJumpscare;
    [SerializeField] Animator jumpscareAnimation;
    public float speed = 1f;
    [Header("Player")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject player;
    [SerializeField] Headbob headbob;
    
    public float sensX; 
    public float sensY;

    AnimatorStateInfo animStateInfo;
    public float NTime;
    bool animationFinished;

    public Transform orientation;
    [SerializeField] GameObject mainCamera;
    float xRotation;
    float yRotation;

    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            CameraMove();
           

        }

        if (isHit)
        {
            ResumeJumpscare();

        }
        if (jumpscareAnimation.GetCurrentAnimatorStateInfo(0).length < jumpscareAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            Debug.Log("animation has finished!!");
        }
    }
        
       

    private void CameraMove()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -70f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void LookAtEnemy()
    {
        isHit = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerMovement.enabled = false;
        enemyMovement.enabled = false;
        headbob.enabled = false;
        enemy.SetActive(false);
        enemyJumpscare.SetActive(true);
        jumpscareAnimation.Play("Jumpscare", 0, 0f);
        







    }
    void ResumeJumpscare()
    {
        if (player.GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            target.transform.position = transform.position;
            
            StartCoroutine(LookAt());
            
        }
    }


    IEnumerator LookAt()
    {
        
        Quaternion lookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0f;

        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            
            time += Time.deltaTime * speed;

            yield return null;
        }

        

        
    }

    


}

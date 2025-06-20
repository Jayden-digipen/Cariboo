using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] GameObject[] enemies;
    [SerializeField]Transform target;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyJumpscare;
    [SerializeField] Animator jumpscareAnimation;
    [SerializeField] AudioClip jumpscareClip;
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

    public bool isHit = false;
    //[SerializeField] static bool anotherJumpscarePlaying = false;
    bool gotAnEnemy = false;
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

        RefreshEnemyTarget();
        Debug.Log(GetClosestEnemy(enemies));


        if (!isHit)
        {
            UpdateEnemiesList();
            
            CameraMove();
            playerMovement.enabled = true;         
            headbob.enabled = true;
            //anotherJumpscarePlaying = false;
            

            if (gotAnEnemy)
            {
                enemyJumpscare.SetActive(false);
                enemyMovement.enabled = true;
                enemy.SetActive(true);
                
            }
           

        }

       
       
    }

   

    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrTarget = directionToTarget.sqrMagnitude;
            if(dSqrTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrTarget;
                bestTarget= potentialTarget;

            }
        }

        
        return bestTarget;
    }

    
    void UpdateEnemiesList()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void RefreshEnemyTarget()
    {
        GameObject closest = GetClosestEnemy(enemies);
        if (closest == null) return;

        //int NumberChildren = closest.transform.childCount;
        //if (NumberChildren < 1) return;

        Transform[] allChildren = closest.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
        {
            if (child.CompareTag("Target"))
                target = child;

            if (child.CompareTag("EnemyGirl"))
            {
                enemy = child.gameObject;
                enemyMovement = enemy.GetComponent<EnemyMovement>();
            }

            if (child.CompareTag("JumpscareGirl"))
            {
                enemyJumpscare = child.gameObject;
                jumpscareAnimation = child.GetComponent<Animator>();
            }

            gotAnEnemy = true;
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

        enemyJumpscare.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        playerMovement.enabled = false;
        enemyMovement.EnemyBackToStart();
        StartCoroutine(DisableEnemyMovement());
       
        headbob.enabled = false;
        enemy.SetActive(false);

       
        jumpscareAnimation.Play("Jumpscare", 0, 0f);
        ResumeJumpscare();

        AudioSource.PlayClipAtPoint(jumpscareClip, mainCamera.transform.position);

    }
    void ResumeJumpscare()
    {
        if (player.GetComponent<Rigidbody>().velocity.magnitude == 0)
        {
            target.transform.position = transform.position;
            
            StartCoroutine(LookAt());
            
        }
    }

    IEnumerator DisableEnemyMovement()
    {
        yield return new WaitForSeconds(1.0f);  
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false;
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

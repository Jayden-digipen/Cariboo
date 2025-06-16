using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float subtractHealth;
    public NavMeshAgent agent;
    public Transform player;
    Vector3 startingPosition;

    public PlayerCamera playerCameraScript;
    public LayerMask isGrounded, isPlayer;

    //Scripts
    PlayerHealth playerHealth;

    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerSightRange, playerAttackRange;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();


    }

    private void Start()
    {
        
        startingPosition = transform.position;
        playerCameraScript = FindObjectOfType<PlayerCamera>();
        
    }

    private void Update()
    {
        LayerMask mask = LayerMask.GetMask("Wall");
        RaycastHit hit;
        playerSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if (!playerSightRange && !playerAttackRange)
        {
            Patroling();
        }

        if (playerSightRange && !playerAttackRange && player.CompareTag("Player") == true)
        {
            ChasePlayer();
        }

        //if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        //{
            //return;
        //}

        else if (playerSightRange && playerAttackRange && player.CompareTag("Player") == true){
            AttackPlayer();
        }
               
            

               
      
    }



    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            //search new walkPoint
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGrounded))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attack code here, implement later when there is a health script
            agent.SetDestination(transform.position);
            playerCameraScript.LookAtEnemy();
            playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.TakeDamage(subtractHealth);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void EnemyBackToStart()
    {
        transform.position = startingPosition;
    }

}

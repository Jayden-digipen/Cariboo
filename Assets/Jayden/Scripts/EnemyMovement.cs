using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    [SerializeField] GameObject player;
    Transform playerTranform;
    // Start is called before the first frame update
    void Start()
    {
        playerTranform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(player.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTranform.position, speed * Time.deltaTime);
        }
            
        
 
       
    }

   
}

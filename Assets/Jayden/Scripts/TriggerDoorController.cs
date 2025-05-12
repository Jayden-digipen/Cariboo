using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDoorController : MonoBehaviour
{
    DoorCrossCheck doorCrossCheck;
    float timeDuration = 1;
    [SerializeField] private Animator myDoor;
    [SerializeField] private bool inTrigger = false;
    [SerializeField] bool doorIsOpen = false;
    [SerializeField] TextMeshPro textOpen;
    [SerializeField] TextMeshPro textClose;
    bool inOpenTrigger = false;
    bool inCloseTrigger = false;
    bool hasCrossedDoor;
    

    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    private void Start()
    {
        doorCrossCheck = FindObjectOfType<DoorCrossCheck>();
        textOpen.text = "";
        textClose.text = "";
    }

    private void Update()
    {
        hasCrossedDoor = doorCrossCheck.hasWalkedThroughDoor;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inTrigger && !doorIsOpen)
            {
                myDoor.Play(doorOpen, 0, 0.0f);
                doorIsOpen = true;
            }

            else if (inTrigger && doorIsOpen)
            {
                myDoor.Play(doorClose, 0, 0.0f);
                doorIsOpen = false;          
            }

            
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
            
            if (!doorIsOpen && !hasCrossedDoor)
            {
                textOpen.text = "E to open";
                    
            }

            else if (!doorIsOpen && hasCrossedDoor)
            {
                textClose.text = "E to open";

            }


            else if (doorIsOpen && hasCrossedDoor)
            {
                
                textClose.text = "E to close";
            }

            else
            {
                textOpen.text = "E to close";
            }
                
                          
            

            
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
            textOpen.text = "";
            textClose.text = "";
            inTrigger = false;
              
                      
        }
    }
}

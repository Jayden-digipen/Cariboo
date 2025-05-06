using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] GameObject textOpen;
    [SerializeField] GameObject textClose;
    public bool inOpenTrigger = false;
    public bool inCloseTrigger = false;

    private void Start()
    {
        textOpen.SetActive(false);
        textClose.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inOpenTrigger)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
            }

            else if (inCloseTrigger)
            {
                myDoor.Play("DoorClose", 0, 0.0f);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                textOpen.SetActive(true);
                inOpenTrigger = true;
                          
            }

            else if (closeTrigger)
            {
                textClose.SetActive(true);
                inCloseTrigger = true;
   
            }
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                textOpen.SetActive(false);
                inOpenTrigger = true;
            }

            else if (closeTrigger)
            {
                textClose.SetActive(false);
                inCloseTrigger = true;
            }
        }
    }
}

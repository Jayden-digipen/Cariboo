using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorShowText : MonoBehaviour
{
    [SerializeField] private TriggerDoorControllerForLockedDoor triggerDoorControllerForLocked;
    [SerializeField] private GameObject interactText;
    [SerializeField] GameObject doorTrigger;

    private bool doorIsOpen = false;
    private void OnTriggerStay(Collider other)
    {

            interactText.SetActive(true);
       

       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.SetActive(false);

        }
    }
}

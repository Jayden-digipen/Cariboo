using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorLocked : MonoBehaviour
{
    [SerializeField] private TextMeshPro doorLockedText;
    [SerializeField] GameObject gameObject;
    [SerializeField] TriggerDoorControllerForLockedDoor doorObject;

    private void Start()
    {
        doorObject = GetComponent<TriggerDoorControllerForLockedDoor>();
        
    }

    private void Update()
    {
        if (doorObject.enabled)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        doorObject = GetComponent<TriggerDoorControllerForLockedDoor>();
        if (!doorObject.enabled)
        {
            doorLockedText.text = "Door is Locked";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorLockedText.text = "";
    }
}

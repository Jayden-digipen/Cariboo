using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCrossCheck : MonoBehaviour
{
    [SerializeField] public bool hasWalkedThroughDoor = false;


    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!hasWalkedThroughDoor)
            {
                hasWalkedThroughDoor = true;
            }

            else if (hasWalkedThroughDoor)
            {
                hasWalkedThroughDoor = false;
            }
            
        }
    }
  
}

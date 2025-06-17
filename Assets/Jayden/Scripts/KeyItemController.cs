using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    
    [SerializeField] private bool redDoor = false;
    [SerializeField] private bool masterDoor = false;


    [SerializeField] private KeyInventory _keyInventory = null;
    Key key;

    private TriggerDoorControllerForLockedDoor doorObject;

    private void Start()
    {
        
        if (redDoor || masterDoor)
        {
           doorObject = GetComponent<TriggerDoorControllerForLockedDoor>();
        }

        


    }

    public void ObjectInteraction()
    {
        if (redDoor || masterDoor)
        {
            doorObject.PlayAnimation();
            
        }

     
    }
}

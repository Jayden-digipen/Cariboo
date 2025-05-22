using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : MonoBehaviour
{
    [SerializeField] TriggerDoorControllerForLockedDoor doorController;
    [SerializeField] private bool redDoor = false;
    [SerializeField] private bool redKey = false;

    [SerializeField] private KeyInventory _keyInventory = null;
    Key key;

    private KeyDoorController doorObject;

    private void Start()
    {
        if (redDoor)
        {
            doorObject = GetComponent<KeyDoorController>();
        }
        
    }

    public void ObjectInteraction()
    {
        if (redDoor)
        {
            doorController.enabled = true;
        }

        else if (redKey)
        {
            key.GetSelectedItemKey();
        }
    }
}

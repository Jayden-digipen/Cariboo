using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;
    [SerializeField] TriggerDoorControllerForLockedDoor triggerDoorControllerForLocked;

    Item item;
    InventoryManager inventoryManager;
    
    float imageShower;
    

    private void Start()
    {
        
    }
    void Update()
    {
        GetSelectedItemKey();
    }

    public void GetSelectedItemKey()
    {
        if ((InventoryManager.instance != null && InventoryManager.instance.selectedSlot != -1))
        {
            Item item = InventoryManager.instance.GetSelectedItem(false);

            if (item != null && item.type == ItemType.Keys)
            {
                _keyInventory.hasRedKey = true;

                if (triggerDoorControllerForLocked.openedRedDoor)
                {
                    _keyInventory.hasRedKey = true;
                    InventoryManager.instance.GetSelectedItem(true);
                }
               
            }

            else if (!triggerDoorControllerForLocked.openedRedDoor)
            {
                _keyInventory.hasRedKey = false;
            }



        }



    }

   
}

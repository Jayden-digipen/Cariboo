using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyInventory _keyInventory = null;
    [SerializeField] float concealmentTime = 10;
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
                    InventoryManager.instance.GetSelectedItem(true);
                }
            }

            if(item != null && item.type != ItemType.Keys)
            {
                _keyInventory.hasRedKey = false;
            }


        }



    }

   
}

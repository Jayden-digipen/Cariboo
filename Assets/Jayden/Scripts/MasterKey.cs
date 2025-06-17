using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterKey : MonoBehaviour
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

            if (item != null && item.type == ItemType.MasterKey)
            {
                _keyInventory.hasMasterKey = true;

                if (triggerDoorControllerForLocked.openedMasterDoor)
                {
                    _keyInventory.hasMasterKey = true;
                    InventoryManager.instance.GetSelectedItem(true);
                }

            }

            else if (!triggerDoorControllerForLocked.openedMasterDoor)
            {
                _keyInventory.hasMasterKey = false;
            }



        }



    }
}

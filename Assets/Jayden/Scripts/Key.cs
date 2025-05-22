using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] float concealmentTime = 10;
    [SerializeField] GameObject player;
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
                InventoryManager.instance.GetSelectedItem(true);
            }


        }



    }

   
}

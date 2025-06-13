using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    PlayerHealth playerHealth;
   
    public float addedHealth = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    void Update()
    {
        GetSelectedItem();
    }

    private void GetSelectedItem()
    {
        if ((InventoryManager.instance != null && InventoryManager.instance.selectedSlot != -1))
        {
            Item item = InventoryManager.instance.GetSelectedItem(false);
            playerHealth = FindObjectOfType<PlayerHealth>();

            if (item != null && Input.GetKey(KeyCode.Mouse0) && item.type == ItemType.Medicine && playerHealth.currentHealth < 100)
            {
                playerHealth = FindObjectOfType<PlayerHealth>();
                Debug.Log("Medicine" + playerHealth);
                playerHealth.currentHealth += addedHealth;


                InventoryManager.instance.GetSelectedItem(true);
                
              

            }


        }



    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Concealment : MonoBehaviour
{
    [SerializeField] float concealmentTime = 10;
    [SerializeField] GameObject player;
    Item item;
    InventoryManager inventoryManager;
    public Image image;
    float imageShower;
    bool isConcealed = false;

    private void Start()
    {      
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
    void Update()
    {
       GetSelectedItem();
    }

    private void GetSelectedItem()
    {
        if((InventoryManager.instance != null &&  InventoryManager.instance.selectedSlot != -1))
        {
            Item item = InventoryManager.instance.GetSelectedItem(false);

            if (item != null && Input.GetKey(KeyCode.Mouse0) && item.type == ItemType.Concealment && isConcealed == false)
            {
                InventoryManager.instance.GetSelectedItem(true);
                isConcealed = true;
                player.tag = "Concealed";
                
                
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                StartCoroutine(Countdown());
                
            }

            
        }
       
       

    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(concealmentTime);
        player.tag = "Player";
        isConcealed=false;
         
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

    }
}

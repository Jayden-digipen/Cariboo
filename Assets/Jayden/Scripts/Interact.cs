using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Interact : MonoBehaviour
{
   
    [SerializeField] Item item;
    public void Initialize(Item item)
    {
        this.item = item;
       
    }
    private void OnTriggerEnter(Collider other)
    {
             
         bool canAdd = InventoryManager.instance.addItem(item);


        if (canAdd)
        {
            Destroy(gameObject);
        }
        
    }

   

}

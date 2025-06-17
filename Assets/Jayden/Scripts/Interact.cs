using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using TMPro;

public class Interact : MonoBehaviour
{
    [SerializeField] GameObject interactText;
    [SerializeField] Item item;
    [SerializeField] AudioClip clip;
    public void Initialize(Item item)
    {
        this.item = item;
       
    }

    private void OnMouseOver()
    {
        interactText.SetActive(true);

        if (Input.GetKey(KeyCode.E))
        {
            bool canAdd = InventoryManager.instance.addItem(item);


            if (canAdd)
            {
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
                Destroy(gameObject);
            }
        }
    }
    public void OnMouseExit()
    {
        interactText.SetActive(false);
    }




}

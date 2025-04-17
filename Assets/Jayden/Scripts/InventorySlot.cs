using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notselectedColor;

    public void Awake()
    {
        Deselect();
    }
    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        
      image.color = notselectedColor;
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggedItem = dropped.GetComponent<DraggableItem>();
            draggedItem.parentAfterDrag = transform;
        }
        
    }

    
}

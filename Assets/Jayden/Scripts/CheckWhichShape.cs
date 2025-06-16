using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhichShape : MonoBehaviour
{
    [SerializeField] private ShapeInventory shapeInventory = null;
  
    // Start is called before the first frame update
    void Start()
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

            if (item != null && item.type == ItemType.Circle)
            {
                shapeInventory.hasCircleShape = true;

               

            }

            if (item != null && item.type == ItemType.Square)
            {
                shapeInventory.hasSquareShape = true;



            }

            if (item != null && item.type == ItemType.Triangle)
            {
                shapeInventory.hasTriangleShape = true;



            }


            if (item != null && item.type == ItemType.Star)
            {
                shapeInventory.hasStarShape = true;



            }



        }



    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhichShape : MonoBehaviour
{
    [SerializeField] private ShapeInventory shapeInventory = null;
    SetPuzzlesActive SetPuzzlesActive;
  
    // Start is called before the first frame update
    void Start()
    {
        SetPuzzlesActive = FindObjectOfType<SetPuzzlesActive>();
    }

    void Update()
    {
        GetSelectedItemKey();
    }

    public void GetSelectedItemKey()
    {
        shapeInventory.hasCircleShape = false;
        shapeInventory.hasSquareShape = false;
        shapeInventory.hasTriangleShape = false;
        shapeInventory.hasStarShape = false;

        if ((InventoryManager.instance != null && InventoryManager.instance.selectedSlot != -1))
        {
            Item item = InventoryManager.instance.GetSelectedItem(false);

            if (item != null && item.type == ItemType.Circle)
            {
                shapeInventory.hasCircleShape = true;

                if (SetPuzzlesActive.isCircleFiled)
                {
                    InventoryManager.instance.GetSelectedItem(true);
                }
                



            }

            if (item != null && item.type == ItemType.Square)
            {
                shapeInventory.hasSquareShape = true;

                if (SetPuzzlesActive.isSquareFilled)
                {
                    InventoryManager.instance.GetSelectedItem(true);
                }
                


            }

            if (item != null && item.type == ItemType.Triangle)
            {
                shapeInventory.hasTriangleShape = true;

                if (SetPuzzlesActive.isTriangleFilled)
                {
                    InventoryManager.instance.GetSelectedItem(true);
                }
                


            }


            if (item != null && item.type == ItemType.Star)
            {
                shapeInventory.hasStarShape = true;
                

                if (SetPuzzlesActive.isStarFilled)
                {
                    InventoryManager.instance.GetSelectedItem(true);
                }

            }



        }



    }

}

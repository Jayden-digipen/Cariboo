using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitPuzzleReplace : MonoBehaviour
{
    [SerializeField] bool isSquare;
    [SerializeField] bool isCircle;
    [SerializeField] bool isTriangle;
    [SerializeField] bool isStar;

   
    

    private ShapeInventory shapeInventory;
    private SetPuzzlesActive setPuzzlesActive;

    private void Start()
    {
        shapeInventory = FindObjectOfType<ShapeInventory>();
        setPuzzlesActive = FindObjectOfType<SetPuzzlesActive>();

       
    }

    private void Update()
    {
        
    }

   

    public void ShapeCheck()
    {
        if (isSquare && shapeInventory.hasSquareShape == true)
        {
            setPuzzlesActive.SquareEnable();
        }

        if (isCircle && shapeInventory.hasCircleShape == true)
        {
            setPuzzlesActive.CircleEnable();
        }

        if (isTriangle && shapeInventory.hasTriangleShape == true)
        {
            setPuzzlesActive.TriangleEnable();
        }

        if (isStar && shapeInventory.hasStarShape == true)
        {
            setPuzzlesActive.StarEnable();
        }

        else
        {
            return;
        }
    }
}

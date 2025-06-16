using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitPuzzleReplace : MonoBehaviour
{
    [SerializeField] bool isSquare;
    [SerializeField] bool isCircle;
    [SerializeField] bool isTriangle;
    [SerializeField] bool isStar;

    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject triangle;
    [SerializeField] GameObject star;

    private ShapeInventory shapeInventory;
    
    public void ShapeCheck()
    {
        if (isSquare && shapeInventory.hasSquareShape == true)
        {
            square.SetActive(true);
        }

        if (isCircle && shapeInventory.hasCircleShape == true)
        {
            circle.SetActive(true);
        }

        if (isTriangle && shapeInventory.hasTriangleShape == true)
        {
            triangle.SetActive(true);
        }

        if (isStar && shapeInventory.hasStarShape == true)
        {
            star.SetActive(true);
        }

        else
        {
            return;
        }
    }
}

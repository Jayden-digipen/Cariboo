using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FittingPuzzleRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string exclusiveLayerName = null;

    private FitPuzzleReplace fitPuzzleReplace;
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private string circleTag = "Circle";
    private string squareTag = "Square";
    private string triangleTag = "Triangle";
    private string starTag = "Star";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(exclusiveLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(circleTag))
            {
                if (!doOnce)
                {
                   
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    Debug.Log("Work");
                    FitPuzzleReplace fitPuzzleReplace = hit.collider.GetComponent<FitPuzzleReplace>();
                    if (fitPuzzleReplace != null)
                    {
                        fitPuzzleReplace.ShapeCheck();
                    }

                }
            }

            if (hit.collider.CompareTag(squareTag))
            {
                if (!doOnce)
                {

                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    Debug.Log("Work");
                    FitPuzzleReplace fitPuzzleReplace = hit.collider.GetComponent<FitPuzzleReplace>();
                    if (fitPuzzleReplace != null)
                    {
                        fitPuzzleReplace.ShapeCheck();
                    }

                }
            }

            if (hit.collider.CompareTag(starTag))
            {
                if (!doOnce)
                {

                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    Debug.Log("Work");
                    FitPuzzleReplace fitPuzzleReplace = hit.collider.GetComponent<FitPuzzleReplace>();
                    if (fitPuzzleReplace != null)
                    {
                        fitPuzzleReplace.ShapeCheck();
                    }
                }
            }

            if (hit.collider.CompareTag(triangleTag))
            {
                if (!doOnce)
                {

                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    Debug.Log("Work");
                    FitPuzzleReplace fitPuzzleReplace = hit.collider.GetComponent<FitPuzzleReplace>();
                    if (fitPuzzleReplace != null)
                    {
                        fitPuzzleReplace.ShapeCheck();
                    }
                }
            }
        }

        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }

        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}

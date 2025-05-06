using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightCanvas : MonoBehaviour
{
    public GameObject flashlightCanvas;
    // Start is called before the first frame update
    void Start()
    {
        flashlightCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlightCanvas.SetActive(false);
        }
    }
}

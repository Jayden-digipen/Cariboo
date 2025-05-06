using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashLightLight;
    private bool flashlightActive = false;


    [SerializeField] AudioClip FlashlightOn;
    private void Start()
    {
        flashLightLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioSource.PlayClipAtPoint(FlashlightOn, Camera.main.transform.position);
            
            if (flashlightActive == false)
            {
                flashLightLight.gameObject.SetActive(true);
                flashlightActive = true;
                
            }
            else
            {
                flashLightLight.gameObject.SetActive(false);
                flashlightActive = false;
                
            }
        }
    }
}

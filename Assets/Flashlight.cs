using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashLightLight;
    private bool flashlightActive = false;
    bool isCooldown = true;
    [SerializeField] GameObject canvas;
    [SerializeField] AudioClip FlashlightOn;
    private void Start()
    {
        canvas.SetActive(true);
        flashLightLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isCooldown)
        {
            canvas.SetActive(false) ;
           StartCoroutine(FlashlightTimer());
        }
    }

    

    IEnumerator FlashlightTimer()
    {
        isCooldown = false;
        if (flashlightActive == false)
        {
            flashLightLight.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(FlashlightOn, Camera.main.transform.position);
            flashlightActive = true;

        }

        else
        {
            flashLightLight.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(FlashlightOn, Camera.main.transform.position);
            flashlightActive = false;

        }

        yield return new WaitForSeconds(0.8f);
        
        isCooldown = true;
        
    }
}

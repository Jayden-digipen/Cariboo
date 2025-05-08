using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightInteract : MonoBehaviour
{
    [SerializeField] TextMeshPro interactText;
    TurnOnlightsbutton turnOnlightsbutton;
    public TurnOnlightsbutton[] lights;
    bool pressed = false;
    public AudioClip lightBuzzSound;
    public AudioSource audioSource;
    private void Start()
    {
        interactText.enabled = false;
        
    }

    public void OnMouseOver()
    {

        interactText.enabled = true;

        if (Input.GetKey(KeyCode.E) && pressed == false)
        {
           audioSource.PlayOneShot(lightBuzzSound);
           
           foreach(TurnOnlightsbutton light in lights)
            {
                light.TurnOnLight();
                pressed = true;
            }
            
        }
      
    }

    public void OnMouseExit()
    {
        interactText.enabled = false;
    }
}

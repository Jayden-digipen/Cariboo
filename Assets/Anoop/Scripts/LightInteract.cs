using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightInteract : MonoBehaviour
{
    [SerializeField] TextMeshPro interactText;
    TurnOnlightsbutton turnOnlightsbutton;
    public TurnOnlightsbutton[] lights;

    public AudioClip lightBuzzSound;
    public AudioSource audioSource;
    private void Start()
    {
        interactText.enabled = false;
        
    }

    public void OnMouseOver()
    {

        interactText.enabled = true;

        if (Input.GetKey(KeyCode.E))
        {
           audioSource.PlayOneShot(lightBuzzSound);        
           foreach(TurnOnlightsbutton light in lights)
            {
                light.TurnOnLight();
            }
            
        }
      
    }

    public void OnMouseExit()
    {
        interactText.enabled = false;
    }
}

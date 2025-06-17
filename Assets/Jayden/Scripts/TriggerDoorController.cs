using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class TriggerDoorController : MonoBehaviour
{
    static TriggerDoorController activeDoor; //  active once at a time
    [SerializeField] GameObject doorTrigger;
    [SerializeField] GameObject interactText;
   

    [SerializeField] private Animator myDoor;
  

    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    [SerializeField] float timer = 1;

    private bool doorIsOpen = false;
    bool isInteracting = false;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openDoor;
    [SerializeField] AudioClip closeDoor;


    private void Start()
    {
        interactText.SetActive(false);
    }
    private void Update()
    {
        timer = Mathf.Clamp(timer, 0f, 1f);

        

        if (activeDoor == this && Input.GetKeyDown(KeyCode.Q) && !isInteracting)
        {
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        isInteracting = true;
        ToggleDoor();
        yield return new WaitForSeconds(timer);
        isInteracting = false;

    }

    public void ToggleDoor()
    {
        if (!doorIsOpen)
        {
            myDoor.Play(doorOpen, 0, 0.0f);
            audioSource.PlayOneShot(openDoor);
            doorIsOpen = true;
            
        }
        else
        {
            myDoor.Play(doorClose, 0, 0.0f);
            audioSource.PlayOneShot(closeDoor);
            doorIsOpen = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeDoor = this;

          
        }
    }

    private void OnTriggerStay(Collider other)
    {
        interactText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && activeDoor == this)
        {
            interactText.SetActive(false);
            activeDoor = null;
        }
    }
}

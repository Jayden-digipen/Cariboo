using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDoorControllerForLockedDoor : MonoBehaviour
{
    static TriggerDoorControllerForLockedDoor activeDoor; //  active once at a time
    [SerializeField] GameObject doorTrigger;
    [SerializeField] GameObject doorController;

    [SerializeField] private Animator myDoor;
    [SerializeField] private TextMeshPro textOpen;
    [SerializeField] private TextMeshPro textClose;

    [SerializeField] private string doorOpen = "DoorOpen";
    [SerializeField] private string doorClose = "DoorClose";

    [SerializeField] float timer = 1;

    private bool doorIsOpen = false;
    bool isInteracting = false;



    private void Start()
    {
        StartCoroutine(CountdownDisable());
        
    }
    private void Update()
    {
        timer = Mathf.Clamp(timer, 0f, 1f);



        if (activeDoor == this && Input.GetKeyDown(KeyCode.E) && !isInteracting)
        {
            StartCoroutine(Countdown());
        }
    }

    IEnumerator CountdownDisable()
    {
        yield return new WaitForSeconds(timer);
        doorController.SetActive(false);
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

            doorIsOpen = true;

        }
        else
        {
            myDoor.Play(doorClose, 0, 0.0f);

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
        bool hasCrossedDoor = doorTrigger.GetComponent<DoorCrossCheck>().hasWalkedThroughDoor;

        if (!doorIsOpen && !hasCrossedDoor)
        {
            textOpen.text = "E to interact";
            textClose.text = "";
            Debug.Log("1");
        }


        else if (doorIsOpen && hasCrossedDoor)
        {
            textClose.text = "E to interact";
            textOpen.text = "";
            Debug.Log("2");


        }

        else if (doorIsOpen && !hasCrossedDoor)
        {

            textOpen.text = "E to interact";
            textClose.text = "";
            Debug.Log("3");

        }

        else
        {
            textClose.text = "E to interact";
            textOpen.text = "";
            Debug.Log("4");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && activeDoor == this)
        {
            textOpen.text = "";
            textClose.text = "";
            activeDoor = null;
        }
    }
}

    


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerDoorControllerForLockedDoor : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;
    public bool openedRedDoor = false;
    public bool openedMasterDoor = false;
    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [SerializeField] private KeyInventory _keyInventory = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openDoor;
    [SerializeField] AudioClip closeDoor;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (_keyInventory.hasRedKey)
        {
            openedRedDoor = true;
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                audioSource.PlayOneShot(openDoor);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }

            else if (doorOpen && !pauseInteraction)
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                audioSource.PlayOneShot(closeDoor);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        else if (_keyInventory.hasMasterKey)
        {
            openedMasterDoor = true;
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                audioSource.PlayOneShot(openDoor);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }

            else if (doorOpen && !pauseInteraction)
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                audioSource.PlayOneShot(closeDoor);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        else
        {
            StartCoroutine(showDoorLocked());
        }
    }

    IEnumerator showDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }


}

    


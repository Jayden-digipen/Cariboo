using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteract : MonoBehaviour
{
    public GameObject noteCanvas;
    public GameObject textRead;
    public GameObject playerCamera;
    public GameObject playerCamerabob;
    public GameObject hud;
    public GameObject inv;
    public GameObject crosshair;

    bool inTrigger = false;
    bool isReadingNote = false;

    private void Start()
    {
        textRead.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        textRead.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        textRead.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && inTrigger)
        {
            noteCanvas.SetActive(true);
            isReadingNote = true;
            hud.SetActive(false);
            inv.SetActive(false);
            crosshair.SetActive(false);
            playerCamera.GetComponent<PlayerCamera>().enabled = false;
            playerCamerabob.GetComponent<Headbob>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

        


    }

    public void Exit()
    {
        noteCanvas.SetActive(false);
        isReadingNote = false;
        inv.SetActive(true);
        hud.SetActive(true);
        crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCamera.GetComponent<PlayerCamera>().enabled = true;
        playerCamerabob.GetComponent<Headbob>().enabled = true;

    }
}

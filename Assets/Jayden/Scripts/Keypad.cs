using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{

    public GameObject player;
    public GameObject playerCamera;
    public GameObject playerCamerabob;
    public GameObject keypad;
    public GameObject hud;
    public GameObject inv;
    public GameObject crosshair;

    public GameObject animateObject;
    public Animator animator;

    public TextMeshProUGUI textObject;
    public string answer = "1234";

    

    public bool animate;

    // Start is called before the first frame update
    void Start()
    {
        keypad.SetActive(false);
    }

    public void Number(int number)
    {
        textObject.text += number.ToString();
        //button.Play();
        
    }

    public void Enter() //check if input is wrong or right
    {
        if (textObject.text == answer)
        {
            //correct.Play();
            textObject.text = "Right";
        }

        else
        {
            //wrong.Play();
            textObject.text = "Wrong";
        }
    }

    public void Clear()
    {
        textObject.text = "";
        //button.Play();
    }

    public void Exit()
    {
        keypad.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        playerCamera.GetComponent<PlayerCamera>().enabled = true;
        playerCamerabob.GetComponent<Headbob>().enabled = true;
        AllSoundActiveAgain();
    }

    public void Update()
    {
        if(textObject.text == "Right" && animate)
        {
            animator.Play("DoorOpen", 0, 0.0f);
            Debug.Log("OPenm");
        }

        if (keypad.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            crosshair.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = false;
            playerCamera.GetComponent<PlayerCamera>().enabled = false;
            playerCamerabob.GetComponent<Headbob>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            MuteAllSound();
        }
    }

    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }
    public void AllSoundActiveAgain()
    {
        AudioListener.volume = 2-;
    }
}

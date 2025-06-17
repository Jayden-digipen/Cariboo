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

    [SerializeField] AudioSource keypadAudioSource;
    [SerializeField] AudioClip buttonClip;
    [SerializeField] AudioClip rightClip;
    [SerializeField] AudioClip wrongClip;

    [SerializeField] private string openAnimationName = "DoorOpen";


    public bool animate;

    // Start is called before the first frame update
    void Start()
    {
        keypad.SetActive(false);
    }

    public void Number(int number)
    {
        textObject.text += number.ToString();
        keypadAudioSource.PlayOneShot(buttonClip);
        
    }

    public void Enter() //check if input is wrong or right
    {
        if (textObject.text == answer)
        {
            keypadAudioSource.PlayOneShot(rightClip);
            textObject.text = "Right";
            Invoke("ClearText", 1f);
        }

        else
        {
            keypadAudioSource.PlayOneShot(wrongClip);
            textObject.text = "Wrong";
            Invoke("ClearText", 1f);
        }
    }

    public void Clear()
    {
        textObject.text = "";
        keypadAudioSource.PlayOneShot(buttonClip);
    }

    private void ClearText()
    {
        textObject.text = "";
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
        
    }

    public void Update()
    {
        if(textObject.text == "Right" && animate)
        {
            animator.Play(openAnimationName, 0, 0.0f);
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
            
        }
    }

    
}

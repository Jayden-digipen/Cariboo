using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    PlayerMovement playerMovement;

    public Image StaminaBar;
    [SerializeField] public float staminaCountdown = 3f;
    


    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

  

    
}

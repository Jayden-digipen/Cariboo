using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int startingHealth = 5;
    [SerializeField] int currentHealth;

    public Image [] hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;  
    }

    

    public void TakeDamage(int damage)
    {
        if(currentHealth > 0)
        {
           
            currentHealth -= damage;
        }
      
    }
}

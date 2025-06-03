using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100;
    [SerializeField] private Image currentHealthBar;
    public float currentHealth { get; private set; }

 
    
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        
    }

    public void TakeDamage(float damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            currentHealthBar.fillAmount = currentHealth / 100f;
            Debug.Log(currentHealth);

        }
      
    }
}

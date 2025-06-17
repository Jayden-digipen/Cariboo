using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100;
    [SerializeField] private Image currentHealthBar;
    public float currentHealth;
    



    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        
    }

    private void Update()
    {
        currentHealthBar.fillAmount = currentHealth / 100f;
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("You died scene");
        }
    }

    public void TakeDamage(float damage)
    {
        if(currentHealth >= 0)
        {
            currentHealth -= damage;
            Debug.Log(currentHealth);

        }
      
    }
}

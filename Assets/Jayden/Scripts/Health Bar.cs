using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHealth;
    

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

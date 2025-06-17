using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    string timeAP = "PM";
    int adjustmentTime = 10;

    // Update is called once per frame
    void Update()
    {

        
        Clock();
        
       
    }

    private void Clock()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString();
        int hours = Mathf.FloorToInt(elapsedTime / 60) + 8;
        int minutes = Mathf.FloorToInt(elapsedTime % 60);
        if (hours == 6)
        {
            SceneManager.LoadScene("You died scene");
        }

        if (hours == 13)
        {
            adjustmentTime = 1;

        }

        if (hours >= 12)
        {
            timeAP = "AM";
        }


        timerText.text = hours.ToString("00") + ":" + minutes.ToString("00") + timeAP;



    }
}

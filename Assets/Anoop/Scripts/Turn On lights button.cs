using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnlightsbutton : MonoBehaviour
{
    public float lightIntensityMultiplier = 1.5f;
    Light myLight;
    public bool hasBeenPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasBeenPressed == false)
        {
            myLight.intensity = Mathf.PingPong(Time.time, lightIntensityMultiplier);
            hasBeenPressed = true;
        } 
    }
}

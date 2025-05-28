using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject NoWayCanvas;
    // Start is called before the first frame update
    void Start()
    {
        NoWayCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        NoWayCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        NoWayCanvas.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    public GameObject keypadParent;
    public GameObject keypadText;

    public bool inReach;
    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inReach = true;
            keypadText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inReach = false;
            keypadText.SetActive(false);
        }
    }




    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && inReach)
        {
            keypadParent.SetActive(true);
        }
    }
}

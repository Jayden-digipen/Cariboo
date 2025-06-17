using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    [SerializeField] GameObject ui;

    private void OnTriggerEnter(Collider other)
    {
        ui.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
   AudioSource audioSource;
   [SerializeField] GameObject text;

    private void Start()
    {
        text.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        text.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            audioSource.Play();
        }
    }
}

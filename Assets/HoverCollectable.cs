using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCollectable : MonoBehaviour
{

    public float amp;
    public Vector3 currentPosition;
    private void Start()
    {
        currentPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(currentPosition.x, Mathf.Sin(Time.time) * amp, currentPosition.z);
    }
}

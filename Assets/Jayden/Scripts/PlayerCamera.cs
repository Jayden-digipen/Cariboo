using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Enemy")]
    public Transform enemyTransform;
    [SerializeField] Transform playerCameraPosition;

    public float sensX; 
    public float sensY;

    public Transform orientation;
    [SerializeField] GameObject mainCamera;
    float xRotation;
    float yRotation;

    bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            CameraMove();
        }
        
       
    }

    private void CameraMove()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -70f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void LookAtEnemy()
    {
        isHit = true;
        mainCamera.transform.LookAt(enemyTransform);
    }
}

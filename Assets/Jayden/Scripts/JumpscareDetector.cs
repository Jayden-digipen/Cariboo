using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareDetector : MonoBehaviour
{
    PlayerCamera playerCamera;

    private void Start()
    {
        playerCamera = FindObjectOfType<PlayerCamera>();
    }
    public void StartAnimation()
    {
        playerCamera.isHit = true;
    }

    public void EndAnimation()
    {
        playerCamera.isHit = false;
    }
}

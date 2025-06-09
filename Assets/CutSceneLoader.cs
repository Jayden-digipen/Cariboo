using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject menuCam = GameObject.FindWithTag("MenuCam");
        Destroy(menuCam);
        SceneManager.LoadScene("Horror Game Best Scene", LoadSceneMode.Single);
    }
}

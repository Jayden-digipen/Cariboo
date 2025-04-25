using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Horror Game", LoadSceneMode.Single);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{


   public void SceneSwitch()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void SceneSwitchd()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SceneSwatch()
    {
        SceneManager.LoadSceneAsync(4);
    }

   
}

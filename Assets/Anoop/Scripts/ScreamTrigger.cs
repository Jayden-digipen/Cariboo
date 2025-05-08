using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamTriggers : MonoBehaviour
{

    [SerializeField] AudioClip screamSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreamEffect());
    }


    IEnumerator ScreamEffect()
    {
        yield return new WaitForSeconds(30);
        AudioSource.PlayClipAtPoint(screamSoundSource, Camera.main.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

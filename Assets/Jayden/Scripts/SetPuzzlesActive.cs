using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPuzzlesActive : MonoBehaviour
{
    [SerializeField] public bool isSquareFilled = false;
    [SerializeField] public bool isCircleFiled = false;
    [SerializeField] public bool isTriangleFilled = false;
    [SerializeField] public bool isStarFilled = false;


    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject triangle;
    [SerializeField] GameObject star;

    [SerializeField] private Animator ani;
    [SerializeField] private string openAnimationName = "Safe open";
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    bool hasPlayedAni = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenSafe();
    }

    private void OpenSafe()
    {
        if (isCircleFiled && isSquareFilled && isStarFilled && isTriangleFilled && hasPlayedAni == false)
        {
            ani.Play(openAnimationName, 0);
            hasPlayedAni = true;
        }
    }

    public void SquareEnable()
    {
        square.SetActive(true);
        isSquareFilled = true;
        audioSource.PlayOneShot(clip);
    }

    public void CircleEnable()
    {
        circle.SetActive(true);
        isCircleFiled = true;
        audioSource.PlayOneShot(clip);
    }

    public void TriangleEnable()
    {
        triangle.SetActive(true);
        isTriangleFilled = true;
        audioSource.PlayOneShot(clip);
    }

    public void StarEnable()
    {
        star.SetActive(true);
        isStarFilled = true;
        audioSource.PlayOneShot(clip);
    }

}

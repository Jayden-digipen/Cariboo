using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    bool hasTriggerDialogue = false;
    bool dialogueFinish = false;
    private int index;
    float timer;
    float timerToEnd;
    [SerializeField] int timeWaitNextLine = 1;
    [SerializeField] int timeWaitDisappear = 5;
    [SerializeField] GameObject dialogueCanvas;




    private void Start()
    {
        dialogueCanvas.SetActive(false);
        textComponent.text = string.Empty;
        
    }
    private void Update()
    {
       
        if(textComponent.text == lines[index])
        {
            timer += Time.deltaTime;

            if(timer >= timeWaitNextLine)
            {
                NextLine();
                timer = 0;
            }
            
           
            
        }

        if (dialogueFinish)
        {
            timerToEnd += Time.deltaTime;

            if (timerToEnd >= timeWaitDisappear)
            {
                gameObject.SetActive(false);

            }
        }
      
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggerDialogue)
        {
            dialogueCanvas.SetActive(true);
            StartDialogue();
            hasTriggerDialogue = true;
        }
        
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }

        else
        {
            dialogueFinish = true;
                    
        }

       
    }

   
   

}





using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private Queue<string> sentences;

    /*
     -Need to pass in actual Dialog.
     -Need to have more control over dialog pace.
     -Need to look for cooler font.
     */


    [SerializeField] private float delay = 0.1f;
    [SerializeField] private string fullText;
    [SerializeField] private string currentText = "";

    public Text nameText;
    public Text sentencesText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

 
    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Starting conversation with " + dialog.name);
        nameText.text = dialog.name;
        

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
            //sentencesText.text = sentence;
            DisplayNextSentence();
            //fullText = sentence;
            Debug.Log("sentence: " + sentence );
        }

       // StartCoroutine(ShowText());
       
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        sentencesText.text = sentence;
        Debug.Log(sentence);
        
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<DialogController>().currentText = currentText;
            yield return new WaitForSeconds(delay);
        }
    }


    private void EndDialog()
    {
        Debug.Log("End of Conversation");
    }
}

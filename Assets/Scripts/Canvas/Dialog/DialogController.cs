using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private Queue<string> _sentences;

    [SerializeField] private Text _nameTxt;
    [SerializeField] private Text _dialogTxt;
    [SerializeField] private Text _xKeyHelp;

    [SerializeField] private float _textSpeed;

    private string _fullTxt;
    private string _currentTxt;

    private UIManager _uiManager;

    private bool _dialogOn;
    private bool _initialDialogHelp;
    
   
    private void Start()
    {
        _sentences = new Queue<string>();
        _uiManager = FindObjectOfType<UIManager>();

     
        if(_uiManager == null)
        {
            Debug.Log("UI Manager is NULL");
        }
        _initialDialogHelp = true;
        _currentTxt = "";

        
    }

    private void Update()
    {
        ContinueDialog();
    }



    public void StartDialog(Dialog dialog)
    {

        _nameTxt.text = dialog.name;
        _dialogOn = true;
        _uiManager.ShowDialogBox(true);
       

        if (_initialDialogHelp)
        {
            _initialDialogHelp = false;
            _xKeyHelp.gameObject.SetActive(true);
        }
        

        foreach (string sentence in dialog.sentences)
        {
            _sentences.Enqueue(sentence);
           
        }

        
        DisplayNextSentence();
    }

    private void ContinueDialog()
    {
        if (Input.GetKeyDown(KeyCode.X) && _dialogOn)
        {
            DisplayNextSentence();
            _xKeyHelp.gameObject.SetActive(false);
        }
    }


    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialog();
            return;
        }
  
        string sentence = _sentences.Dequeue();
        _fullTxt = sentence;
        StartCoroutine(ShowTextTypeWrite());

    }

    private void EndDialog()
    {
        Debug.Log("Conversation over.");
        _uiManager.ShowDialogBox(false);
        _dialogOn = false;
    }

    IEnumerator ShowTextTypeWrite()
    {
        for(int i = 0; i < _fullTxt.Length; i++)
        {
            _currentTxt = _fullTxt.Substring(0, i);
            _dialogTxt.text = _currentTxt;
            yield return new WaitForSeconds(_textSpeed);
        }
      
    }
}

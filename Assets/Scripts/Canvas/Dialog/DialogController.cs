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
    [SerializeField] private Image _dialogImage;
    [SerializeField] private Text _btnTxt;

    [SerializeField] private float _textSpeed;

    private string _fullSentence;
    private string _currentChar;

    private CanvasManager _canvasManager;

    private bool _dialogOn;
    private bool _initialDialogHelp;
    
   
    private void Start()
    {
        _sentences = new Queue<string>();
        _canvasManager = FindObjectOfType<CanvasManager>();

     
        if(_canvasManager == null)
        {
            Debug.Log("UI Manager is NULL");
        }
        _initialDialogHelp = true;
        _currentChar = "";

        
    }


    private void Update()
    {
        ContinueDialog();
    }



    public void StartDialog(Dialog dialog)
    {

        _nameTxt.text = dialog.name;
        _dialogImage.sprite = dialog.charImageSprite;
        _dialogOn = true;
        _canvasManager.ShowDialogBox(true);
       

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

        if (_sentences.Count == 1)
        {
            _btnTxt.text = "<CLOSE>";
        }
  
        string sentence = _sentences.Dequeue();
        _fullSentence = sentence;
        StartCoroutine(ShowTextTypeWrite());
    }


    public void StartGammieDialog(Dialog dialog)
    {

    }


    private void EndDialog()
    {
        Debug.Log("Conversation over.");
        _canvasManager.ShowDialogBox(false);
        _dialogOn = false;
    }


    IEnumerator ShowTextTypeWrite()
    {
        for(int i = 0; i < _fullSentence.Length; i++)
        {
            _currentChar = _fullSentence.Substring(0, i);
            _dialogTxt.text = _currentChar;
            yield return new WaitForSeconds(_textSpeed);
        }  
    }
}

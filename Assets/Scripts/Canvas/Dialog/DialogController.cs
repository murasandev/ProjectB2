using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {


    private Queue<string> _sentences;
    private Queue<Sprite> _sprites;

    [SerializeField] private Text _nameTxt;
    [SerializeField] private Text _dialogTxt;
    [SerializeField] private Text _eKeyHelp;
    [SerializeField] private Image _charImage;
    [SerializeField] private Text _contBtnTxt;

    [SerializeField] private float _textSpeed;

    private string _fullSentence;
    private string _currentChar;

    private CanvasManager _canvasManager;
    private NewPlayer _player;

    private bool _dialogOn;
    private bool _initialDialogHelp;
    private int _dialogNum = 0;

    private Dialog _dialog;

    private static DialogController _instance;
    public static DialogController Instance { get { return _instance;  } }

  
    private void Awake()
    {
            _instance = this;
            DontDestroyOnLoad(this);
    }
 

    private void Start()
    {
        _sentences = new Queue<string>();
        _canvasManager = FindObjectOfType<CanvasManager>();
        _player = FindObjectOfType<NewPlayer>();

        if (_player == null)
        {
            Debug.Log("Player is NULL");
        }

        if (_canvasManager == null)
        {
            Debug.Log("UI Manager is NULL");
        }
        _initialDialogHelp = true;
        _currentChar = "";
    }


    private void Update()
    {
        ContinueDialog(_dialog);
    }

    public void StartDialog(Dialog dialog)
    {

        _dialogOn = true;
        _canvasManager.ShowDialogBox(true);
        var dList = dialog._dialogList;
        _dialog = dialog;

        if (_initialDialogHelp)
        {
            _initialDialogHelp = false;
            _eKeyHelp.gameObject.SetActive(true);
        }


        for (int i = 0; i < dList.Count; i++)
        {

            _nameTxt.text = dList[i].character.name;
            _sentences.Enqueue(dialog._dialogList[i].dialogText);
            _dialogNum = 0;

        }

        DisplayNextSentence(dialog);
    }


    private void ContinueDialog(Dialog dialog)
    {
        if (Input.GetKeyDown(KeyCode.E) && _dialogOn)
        {
            DisplayNextSentence(dialog);
            _eKeyHelp.gameObject.SetActive(false);
        }
    }


    public void DisplayNextSentence(Dialog dialog)
    {
        if (_sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        if (_sentences.Count == 1)
        {
            _contBtnTxt.text = "<CLOSE>";
        }

        string sentence = _sentences.Dequeue();
        Sprite sprite = _dialog._dialogList[_dialogNum].character.charSprite;
        if (_dialogNum < _dialog._dialogList.Count - 1)
        {
            _dialogNum++;
        }

        _charImage.sprite = sprite;
        _fullSentence = sentence;
        StartCoroutine(ShowTextTypeWrite());
    }


    private void EndDialog()
    {
        Debug.Log("Conversation over.");
        _canvasManager.ShowDialogBox(false);
        _dialogOn = false;
    }


    IEnumerator ShowTextTypeWrite()
    {
        for (int i = 0; i <= _fullSentence.Length; i++)
        {
            _currentChar = _fullSentence.Substring(0, i);
            _dialogTxt.text = _currentChar;
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [TextArea(3, 10)] [SerializeField] private String[] _helpTxtString;
    [SerializeField] private Text _helpDisplayTxt;
    [SerializeField] private float _txtSpeedDelay;

    //should move to player class
    [SerializeField] private int _helpLevel;

    private String _currentChar;
    private NewPlayer _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<NewPlayer>();
        //StartCoroutine(ShowTextTypeWrite());
    }
    void Update()
    {
        //need to change _helpLevel to _player._helpLevel
        _helpDisplayTxt.text = _helpTxtString[_helpLevel];
    }

    IEnumerator ShowTextTypeWrite()
    {
        for (int i = 0; i <= _helpTxtString.Length; i++)
        {
            _currentChar = _helpTxtString[0].Substring(0, i);
            _helpDisplayTxt.text = _currentChar;
            yield return new WaitForSeconds(_txtSpeedDelay);
        }
    }
}

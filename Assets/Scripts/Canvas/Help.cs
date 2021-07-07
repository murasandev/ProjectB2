using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    [TextArea(3, 10)] [SerializeField] private String _helpTxtString;
    [SerializeField] private Text _helpDisplayTxt;
    [SerializeField] private float _txtSpeedDelay;

    private String _currentChar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowTextTypeWrite());
    }


    IEnumerator ShowTextTypeWrite()
    {
        for (int i = 0; i <= _helpTxtString.Length; i++)
        {
            _currentChar = _helpTxtString.Substring(0, i);
            _helpDisplayTxt.text = _currentChar;
            yield return new WaitForSeconds(_txtSpeedDelay);
        }
    }
}

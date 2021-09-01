using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Help : MonoBehaviour
{
    [TextArea(3, 10)] [SerializeField] private String[] _helpTxtString;
    [SerializeField] private Text _helpDisplayTxt;
    [SerializeField] private float _txtSpeedDelay;

    [SerializeField] private GameObject _helpGeneral;
    [SerializeField] private GameObject _helpClue;


    private int _helpLevel;
    private NewPlayer _player;
    private EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {

        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();

        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _eventManager.NewHelpText += UpdateHelpTxt;

        _player = FindObjectOfType<NewPlayer>();
        _helpLevel = _player.helpLevel;
        _helpDisplayTxt.text = _helpTxtString[_helpLevel];

    }

   public void UpdateHelpTxt(int helpLevel) => _helpDisplayTxt.text = _helpTxtString[helpLevel];


    public void DisplayGeneralHelp()
    {
        _helpGeneral.gameObject.SetActive(true);
        _helpClue.gameObject.SetActive(false);
    }

    public void DisplayClueHelp()
    {
        _helpGeneral.gameObject.SetActive(false);
        _helpClue.gameObject.SetActive(true);
    }


    private void OnDestroy()
    {
        _eventManager.NewHelpText -= UpdateHelpTxt;
    }
}

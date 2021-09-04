using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundClub : MonoBehaviour
{
    private DialogTrigger _dt;
    private EventManager _eventManager;
    private CanvasManager _canvas;
    private bool _isHelpActive;


    private int _timesLooked;
    private bool _clubFound;

    // Start is called before the first frame update
    void Start()
    {
        _clubFound = true;
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _canvas = FindObjectOfType<CanvasManager>();

        _dt = GetComponent<DialogTrigger>();
        _dt.SetActiveOnEnterFalse();

        _eventManager.ClubFound += StartHintDialog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isHelpActive)
        {
            _isHelpActive = false;
            _canvas.FindClubHelp(_isHelpActive);
        }
            
        if (_dt.activeOnEnter)
            _dt.SetActiveOnEnterFalse();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int looksNeeded = Random.Range(2, 4);
       
        if (other.CompareTag("Player"))
            _timesLooked++;

        if(_timesLooked >= looksNeeded && _clubFound)
        {
            _isHelpActive = true;
            _canvas.FindClubHelp(_isHelpActive);
            _clubFound = false;
        }
           
    }

    public void StartHintDialog() => _dt.TriggerDialog();

    private void OnDestroy() =>_eventManager.ClubFound -= StartHintDialog;
    
}

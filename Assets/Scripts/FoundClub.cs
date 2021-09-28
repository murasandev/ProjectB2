using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundClub : MonoBehaviour
{
    private DialogTrigger _dt;
    private EventManager _eventManager;
    private EtoInteract _eToInteract;
    private bool _eToInteractActive;

    private bool _clubNotFound;

    // Start is called before the first frame update
    void Start()
    {
        _clubNotFound = true;
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _eToInteract = GetComponentInChildren<EtoInteract>();
        if (_eToInteract == null)
            Debug.Log("Player Canvas is NULL");

        _dt = GetComponent<DialogTrigger>();
        if (_dt == null)
            Debug.Log("Dialog Trigger is NULL");

        _dt.SetActiveOnEnterFalse();

        _eventManager.ClubFound += StartHintDialog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _eToInteractActive)
        {
            _eToInteractActive = false;
            _eToInteract.EtoInteractIsActive(_eToInteractActive);
            _clubNotFound = false;
        }
            
        if (_dt.activeOnEnter)
            _dt.SetActiveOnEnterFalse();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_clubNotFound)
        {
            _eToInteractActive = true;
            _eToInteract.EtoInteractIsActive(_eToInteractActive);
        }        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (_clubNotFound)
        {
            _eToInteractActive = false;
            _eToInteract.EtoInteractIsActive(_eToInteractActive);
        }
    }

    public void StartHintDialog() => _dt.TriggerDialog();

    private void OnDestroy() =>_eventManager.ClubFound -= StartHintDialog;
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundClub : MonoBehaviour
{
    private DialogTrigger _dt;
    private EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _dt = GetComponent<DialogTrigger>();
        _dt.SetIntitalDialogFalse();

        _eventManager.ClubFound += StartHintDialog;
    }

    private void Update()
    {
        if (_dt.initialDialog)
            _dt.SetIntitalDialogFalse();
    }
    public void StartHintDialog() => _dt.TriggerDialog();

    private void OnDestroy()
    {
        _eventManager.ClubFound -= StartHintDialog;
    }
}

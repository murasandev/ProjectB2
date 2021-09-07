/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    [SerializeField]private bool _initialDialog;
    public bool initialDialog { get { return _initialDialog; } }

    private void Start()
    {
        _initialDialog = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _initialDialog)
        {
     
           TriggerDialog();
            _initialDialog = false;
        }
    }

    public void SetIntitalDialogFalse() => _initialDialog = false;


    public void TriggerDialog()
    {
        DialogController.Instance.StartDialog(dialog);
        
    }
}*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    [SerializeField] private bool _activeOnEnter;
    public bool activeOnEnter { get { return _activeOnEnter; } }

    [SerializeField] private bool _dialogTriggerOn;
    public bool dialogTriggerOn { get { return _dialogTriggerOn; } }

    private void Start()
    {
        _activeOnEnter = true;
        _dialogTriggerOn = true;
    }

    public void SetActiveOnEnterFalse() => _activeOnEnter = false;

    public void TurnOffDialogTrigger() => _dialogTriggerOn = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _activeOnEnter)
        {

            TriggerDialog();
            _activeOnEnter = false;
        }
    }

    public void TriggerDialog()
    {
        if (_dialogTriggerOn)
            DialogController.Instance.StartDialog(dialog);
    }
}

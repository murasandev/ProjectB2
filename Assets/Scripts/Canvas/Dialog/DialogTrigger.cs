using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    private bool _initialDialog;
  

    private void Start()
    {
        _initialDialog = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _initialDialog)
        {
            if (dialog.startDialogOnContact)
            {
                TriggerDialog();
                _initialDialog = false;
            }
            if (dialog.gammieSceneDialog)
            {
                TriggerGammieDialog();
                _initialDialog = false;
            }
        }
    }

    private void TriggerGammieDialog()
    {
        FindObjectOfType<DialogController>().StartGammieDialog(dialog);
    }

    public void TriggerDialog()
    {
        //convert to singleton?
        FindObjectOfType<DialogController>().StartDialog(dialog);
    }
}

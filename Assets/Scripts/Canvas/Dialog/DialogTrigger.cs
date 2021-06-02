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
   
                if (!dialog.gammySceneDialog)
                {
                    TriggerDialog();
                    _initialDialog = false;
                }
                else if (dialog.gammySceneDialog)
                {
                    TriggerGammySceneDialog();
                    _initialDialog = false;
                }
            }
        }
    }

    public void TriggerGammySceneDialog()
    {
        FindObjectOfType<DialogController>().StartGammyDialog(dialog);
    }

    public void TriggerDialog()
    {
        //convert to singleton?
        FindObjectOfType<DialogController>().StartDialog(dialog);
    }
}

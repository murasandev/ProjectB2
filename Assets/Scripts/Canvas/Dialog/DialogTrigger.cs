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
      

           TriggerDialog();
        }
    }



    public void TriggerDialog()
    {
        DialogController.Instance.StartDialog(dialog);
        
    }
}

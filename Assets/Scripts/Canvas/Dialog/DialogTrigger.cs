using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    private DialogTrigger _dialogTrigger;
    private bool _initialDialog;

    private void Start()
    {
        _dialogTrigger = FindObjectOfType<DialogTrigger>();
        _initialDialog = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _initialDialog)
        {
            _dialogTrigger.TriggerDialog();
            _initialDialog = false; 
        }
    }


    public void TriggerDialog()
    {
        //convert to singleton?
        FindObjectOfType<DialogController>().StartDialog(dialog);
    }
}

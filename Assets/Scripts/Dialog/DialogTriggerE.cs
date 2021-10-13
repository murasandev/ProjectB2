using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerE : MonoBehaviour
{
    private DialogTrigger _dt;
    private EtoInteract _eKey;
    private bool _inOnTrigger;
    private bool _initialDialog;


    // Start is called before the first frame update
    void Start()
    {
        _dt = GetComponent<DialogTrigger>();
        _eKey = GetComponentInChildren<EtoInteract>();

        _initialDialog = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_dt.activeOnEnter)
            _dt.SetActiveOnEnterFalse();

        if (_inOnTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E) && _initialDialog)
            {
                _dt.TriggerDialog();
                _eKey.EtoInteractIsActive(false);
                _initialDialog = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _initialDialog)
        {
            _inOnTrigger = true;
            _eKey.EtoInteractIsActive(true);
        }
        else
        {
            _initialDialog = false;
        }
            
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _initialDialog)
        {
            _inOnTrigger = false;
            _eKey.EtoInteractIsActive(false);
        }     
    }
}

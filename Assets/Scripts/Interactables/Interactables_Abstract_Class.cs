using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Interactables_Abstract_Class : MonoBehaviour
{

    protected CanvasManager _canvas;
    private bool _interactable;

    protected virtual void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        if (_canvas == null)
            Debug.Log("Canvas is NULL");
    }

    protected virtual void Update()
    {
        if (_interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.ShowHelpText();
            _interactable = true;
            Debug.Log("Interactable is active....and _interactable bool is :" + _interactable);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.HideHelpText();
            _interactable = false;
        }
    }

    protected virtual void Interact()
    {
        
        
          
    }
}

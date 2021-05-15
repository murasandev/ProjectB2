using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Interactables_Abstract_Class : MonoBehaviour
{

    private CanvasManager _canvas;
    private bool _interactable;

    public virtual void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        if (_canvas == null)
            Debug.Log("Canvas is NULL");
    }

    public virtual void Update()
    {
        Interact();
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.ShowHelpText();
            _interactable = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canvas.HideHelpText();
            _interactable = false;
        }
    }

    public virtual void Interact()
    {
        if (_interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _canvas.NovelPanelActive();
            }
        }
    }
}

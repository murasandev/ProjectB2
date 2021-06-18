using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : Interactables_Abstract_Class
{
    protected override void Interact()
    {
        Debug.Log("Novel Panel Active now...");
        _canvas.NovelPanelActive();
    }
}

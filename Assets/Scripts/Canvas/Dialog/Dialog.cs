using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class Dialog
{
    public string name;
    public Sprite charImageSprite;
    public bool startDialogOnContact;

    [TextArea(3, 10)] public string[] sentences;
 
}

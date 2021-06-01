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
    public bool gammieSceneDialog;


    public Dictionary<string, string[]> _dialogKeys = new Dictionary<string, string[]>();
    [TextArea(3, 10)] public string[] sentences;
 
}

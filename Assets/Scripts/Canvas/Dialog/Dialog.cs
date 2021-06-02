using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DialogList
{
    [SerializeField] private string _dialogName;
    [TextArea(3, 10)] public string[] _sentences;
    
}


[System.Serializable]
public class Dialog
{
    public string name;
    public Sprite charImageSprite;
    public bool startDialogOnContact;
    public bool gammySceneDialog;

    public List<DialogList> _dialogList;
    [TextArea(3, 10)] public string[] sentences;
 
}



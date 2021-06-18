using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DialogInfo
{


    public Characters character;
    [TextArea(3, 10)] public string dialogText;


    }



[System.Serializable]
[CreateAssetMenu (fileName = "New Scene Dialog", menuName = "Scene Dialogs")]
public class Dialog : ScriptableObject
 {
   
     public List<DialogInfo> _dialogInfo;
}



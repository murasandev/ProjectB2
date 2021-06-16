using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class DialogList
{


    public Characters character;
    [TextArea(3, 10)] public string dialogText;


    }



[System.Serializable]
[CreateAssetMenu (fileName = "New Conversation", menuName = "Conversations")]
public class Dialog : ScriptableObject
 {
   
     public List<DialogList> _dialogList;
}



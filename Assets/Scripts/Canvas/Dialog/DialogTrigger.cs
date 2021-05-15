using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialog()
    {
        //convert to singleton?
        FindObjectOfType<DialogController>().StartDialog(dialog);
    }
}

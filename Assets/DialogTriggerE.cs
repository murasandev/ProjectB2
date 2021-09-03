using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTriggerE : MonoBehaviour
{
    private DialogTrigger _dt;
    // Start is called before the first frame update
    void Start()
    {
        _dt = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dt.activeOnEnter)
            _dt.SetActiveOnEnterFalse();

        if (Input.GetKeyDown(KeyCode.E))
        {
            _dt.TriggerDialog();
        }
    }
}

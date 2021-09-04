using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour
{
    public LeverTrigger _leverTrigger;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _leverTrigger = GameObject.Find("Lever").GetComponent<LeverTrigger>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_leverTrigger.ActivateBool == true)
        {
            _anim.SetBool("Drop", true);
        }
        else
        {
            _anim.SetBool("Drop", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Object"))
        {
            _anim.SetBool("Activate", true);
        }
    }
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Object"))
        {
            _anim.SetBool("Activate", false);
        }
    }
}

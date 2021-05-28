using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.name);

        if (other.tag == "Weapon")
        {
            _anim.SetTrigger("Hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Jump(bool jump)
    {
        _anim.SetBool("Jump", jump);
    }
    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }
}

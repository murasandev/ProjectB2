using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private Animator _anim;
    private NewPlayer _player;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _player = FindObjectOfType<NewPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.name);

        //items only breakable when raging
        if (other.tag == "Weapon" || other.tag == "Object")
        {
            if (_player.isRaging == true)
            {
                _anim.SetTrigger("Hit");
                if (this.tag == "Chest")
                {
                    _player.rageTutorialChest();
                }
            }
        }
        if (other.CompareTag("Bird Cage"))
        {
            _anim.SetTrigger("Hit");
        }
    }
}

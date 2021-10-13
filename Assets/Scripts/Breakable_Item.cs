using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Item : MonoBehaviour
{
    private NewPlayer _player;
    private Animator _anim;
    [SerializeField] private BoxCollider2D _bc;
    [SerializeField] private GameObject _table;

    private void Start()
    {
        _player = FindObjectOfType<NewPlayer>();
        _anim = GetComponent<Animator>();

        _bc = GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(_bc, _table.GetComponent<BoxCollider2D>());
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("table_break"))
        {
            Animator animator = _table.GetComponent<Animator>();
            animator.SetTrigger("Hit");
            HandleTrigger(false);
            CameraShake.Instance.ShakeCamera(10.0f, .5f);
        }

        if (other.tag == "Weapon")
        {
            if (_player.isRaging == true)
            {
                CameraShake.Instance.ShakeCamera(2.0f, 0.1f);
                _player.HitItem();
                Destroy(this.gameObject);
             //   _anim.SetTrigger("Hit");
            }
        }
    }


    private void HandleTrigger(bool isEnabled) => _bc.isTrigger = isEnabled;
    

}

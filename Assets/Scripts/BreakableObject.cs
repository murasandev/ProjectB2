using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private Animator _anim;
    private NewPlayer _player;
    [SerializeField] private BoxCollider2D _bc;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _player = FindObjectOfType<NewPlayer>();
        _bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        //items only breakable when raging
        if (other.tag == "Weapon" || other.tag == "Object")
        {
            if (_player.isRaging == true)
            {
                ActivateAnim();
                _player.rageTutorialPlusOne();

                if (this.tag == "Chest")
                {
                    _player.rageTutorialChest();
                }
                _player.HitItem();
                CameraShake.Instance.ShakeCamera(2.0f, 0.1f);
            }
        }
        if (other.CompareTag("Bird Cage"))
        {
            ActivateAnim();
            CameraShake.Instance.ShakeCamera(5.0f, 0.1f);
        }
        if (other.CompareTag("Weapon"))
        {
            _bc.enabled = false;
        }
    }

    public void ActivateAnim() => _anim.SetTrigger("Hit");
}

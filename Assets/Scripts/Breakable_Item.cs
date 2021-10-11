using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Item : MonoBehaviour
{
    private NewPlayer _player;

    private void Start()
    {
        _player = FindObjectOfType<NewPlayer>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Weapon")
        {
            if (_player.isRaging == true)
            {

                CameraShake.Instance.ShakeCamera(2.0f, 0.1f);
            _player.HitItem();
                Destroy(this.gameObject);
            }
        }
    }

 
}

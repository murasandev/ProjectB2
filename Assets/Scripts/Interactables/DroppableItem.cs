using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private Animator _anim;
    private EventManager _eventManager;
    private Collider2D _water;
    private Collider2D _c2D;
    private Collider2D _playerCollider;
    
  


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _c2D = GetComponent<Collider2D>();

        _water = GameObject.Find("Water").GetComponent<Collider2D>();
        _playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            _rb.gravityScale = 1.0f;
            _anim.enabled = false;

            switch (gameObject.name)
            {
                case "Bird_Cage":
                    _eventManager.BirdCageKnockedDown();
                    CameraShake.Instance.ShakeCamera(5.0f, .1f);
                    break;

                case "Crate":
                    UpdateHelpTxtCrate();
                    CameraShake.Instance.ShakeCamera(5.0f, .1f);
                    break;

                default:
                    Debug.Log("Error: Value NUll");
                    break;

            }
        }
        if (other.CompareTag("Water"))
        {
            Physics2D.IgnoreCollision(_c2D, _water);
        }

        //if (other.CompareTag("Player"))
        //{
        //    Physics2D.IgnoreCollision(_c2D, _playerCollider);
        //}
    }

    public void UpdateHelpTxtCrate()
    {
        int helpLvl = 2;
        _eventManager.UpdateHelpText(helpLvl);
    }
}

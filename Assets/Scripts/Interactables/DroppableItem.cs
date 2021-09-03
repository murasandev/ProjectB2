using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private Animator _anim;
    private EventManager _eventManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

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
                    break;

                case "Crate":
                    UpdateHelpTxtCrate();
                    break;

                default:
                    Debug.Log("Error: Value NUll");
                    break;

            }
        }
    }

    public void UpdateHelpTxtCrate()
    {
        int helpLvl = 2;
        _eventManager.UpdateHelpText(helpLvl);
    }
}

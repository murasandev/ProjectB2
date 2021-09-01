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
  

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _c2D = GetComponent<Collider2D>();

        _water = GameObject.Find("Water").GetComponent<Collider2D>();
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            _rb.gravityScale = 1.0f;
            _anim.enabled = false;
            UpdateHelpTxt();
          
        }
        if (other.CompareTag("Water"))
        {
            Physics2D.IgnoreCollision(_c2D, _water);
        }
    }

    public void UpdateHelpTxt()
    {
        int helpLvl = 2;
        _eventManager.UpdateHelpText(helpLvl);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableItem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
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
        }
    }
}

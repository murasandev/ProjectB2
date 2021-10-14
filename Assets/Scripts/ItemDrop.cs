using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _bc;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _animator;

    Vector3 lastPosition = Vector3.zero;
    private float _speed;

    // Start is called before the first frame update
    private void Start()
    {
        //reference player rage
        _bc = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        Speed();
        if (_speed == 0.0f)
        {
            DisableMass();
            EnableTrigger();
            ActivateAnimator();
        }
    }

    private void EnableTrigger()
    {
        _bc.isTrigger = true;
    }
    private void DisableMass()
    {
        _rb.mass = 0.0f;
        _rb.gravityScale = 0.0f;
    }
    private void Speed()
    {
        _speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }
    private void ActivateAnimator()
    {
        _animator.enabled = true;
    }
}

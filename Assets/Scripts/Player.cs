using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 10f;
    private Animator _anim;
    private Vector3 _direction;
    private SpriteRenderer _spriteR;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(hInput));
        _direction = new Vector3(hInput, 0, 0) * _speed;
        _controller.Move(_direction * Time.deltaTime);

        if (hInput < 0)
        {
            _spriteR.flipX = true;
        }
        else
        {
            _spriteR.flipX = false;
        }

    }
}

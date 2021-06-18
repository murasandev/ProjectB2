using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PhysicsObject
{
    #region PlayerVariables
    //[SerializeField] private float _speed = 10f;
    //[SerializeField] private float _jumpForce = 20f;
    //[SerializeField] private float _fallingGravity = 2f;
    #endregion

    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteR;
    private CanvasManager _canvas;

    private Vector3 _direction;

    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;

    void Start()
    {
        /*_rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();
        _canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        if (_canvas == null)
        {
            Debug.LogError("The Canvas is NULL.");
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CalculateMovement();
    }

    private void Update()
    {
        //targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);

        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    velocity.y = jumpPower;
        //}


        /*if (_rb.velocity.y < 0)
        {
            _rb.gravityScale = _fallingGravity;
        }
        else
        {
            _rb.gravityScale = 1f;
        }*/
    }

    /*void CalculateMovement()
    {
        float hInput = Input.GetAxis("Horizontal") * Time.deltaTime;
        _anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        _direction = new Vector3(hInput * _speed, _rb.velocity.y, 0);
        _rb.velocity = _direction;
       
       

        if (hInput < 0)
        {
            _spriteR.flipX = true;
        }
        else
        {
            _spriteR.flipX = false;
        }

        /*
        if (_rb.OverlapCir)
        {

        }

    }

    void Jump()
    {
        // Need a boolean to disable further jumping deactivates when touching the ground, probably reacts when colliding with ground tagged colliders.
        //_rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            velocity.y = jumpPower;
        
    }*/
}

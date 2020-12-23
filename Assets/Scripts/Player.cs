using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 10f;
    private Animator _anim;
    private Vector3 _direction;
    private SpriteRenderer _spriteR;
    private CanvasManager _canvas;
    private bool _interactable;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();
        _canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        if (_canvas == null)
        {
            Debug.LogError("The Canvas is NULL.");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateMovement();
    }

    private void Update()
    {
        Interact();
    }

    void CalculateMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(hInput));
        _direction = new Vector3(hInput, 0, 0) * _speed;
        _rb.velocity = (_direction * Time.deltaTime);

        if (hInput < 0)
        {
            _spriteR.flipX = true;
        }
        else
        {
            _spriteR.flipX = false;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            _canvas.ShowHelpText();
            _interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bookshelf"))
        {
            _canvas.HideHelpText();
            _interactable = false;
        }
    }

    private void Interact()
    {
        if (_interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _canvas.NovelPanelActive();
            }
        }
    }
}

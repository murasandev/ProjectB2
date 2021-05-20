using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;

    private PlayerAnimation _anim;
    private SpriteRenderer _spriteR;
    private CanvasManager _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<PlayerAnimation>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();
        _canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();

        if (_canvas == null)
        {
            Debug.LogError("The Canvas is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _anim.Attack();
        }
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        _anim.Move(Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < 0)
        {
            //_spriteR.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            //_spriteR.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
            _anim.Jump(true);
            StartCoroutine(ResetJumpCoroutine());
        }
    }
    IEnumerator ResetJumpCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _anim.Jump(false);
    }
}

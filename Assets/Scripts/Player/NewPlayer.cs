using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;

    [SerializeField] private int rage = 0;
    [SerializeField] private bool enrage = false;
    [SerializeField] private int subtractRage = 5;
    [SerializeField] private bool boolRage;
    [SerializeField] private bool stopActions = false;

    [SerializeField] private bool hasClub = false;

    [SerializeField] private bool teachRage = true;

    private PlayerAnimation _anim;
    private SpriteRenderer _spriteR;
    private CanvasManager _canvas;

    [SerializeField] private Transform gammieTransform;

    /*[SerializeField] AudioClip _sfxSource;
    [SerializeField] private float _sfxVolume = 1.0f;
    */

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
        ActivateRage();
        TeachBromRage();
        if (stopActions == false)
        {
            if (Input.GetButtonDown("Fire1") && hasClub == true)
            {
                _anim.Attack();

                /* if (_sfxSource != null)
                {
                    AudioManager.Instance.PlayEffect(_sfxSource, _sfxVolume);
                } */
            }
            targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
            _anim.Move(Mathf.Abs(Input.GetAxis("Horizontal")));

            if (Input.GetAxis("Horizontal") < 0)
            {
                //_spriteR.flipX = true;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetAxis("Horizontal") > 0)
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
        
    }
    IEnumerator ResetJumpCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _anim.Jump(false);
    }
    void ActivateRage()
    {
        if (rage >= 100 && enrage == false)
        {
            _anim.Rage();
            enrage = true;
            boolRage = true;
            stopActions = true;
            StartCoroutine(StartRageRoutine());
        }
        else if (rage <= 0)
        {
            enrage = false;
            _spriteR.color = new Color(1f, 1f, 1f, 1f);
        }
        //Coroutine to start rage counter
        if (enrage == true && boolRage == true)
        {
            StartCoroutine(LoseRageRoutine());
            boolRage = false;
        }
    }
    IEnumerator StartRageRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        stopActions = false;
        _spriteR.color = new Color(.9686f, .5725f, .4823f, 1f);
    }
    IEnumerator LoseRageRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        rage -= subtractRage;
        boolRage = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("FindClub"))
        {
            Debug.Log("Press 'Enter' to obtain club!");

            if (Input.GetKeyDown(KeyCode.Return))
            {
                hasClub = true;
                Debug.Log("Club obtained!");
            }
        }
    }
    private void TeachBromRage()
    {
        float dist = Vector3.Distance(transform.position, gammieTransform.position);
        if (dist < 2.0f && teachRage == true)
        {
            StartCoroutine(TeachRageRoutine());
            teachRage = false;
        }
    }
    IEnumerator TeachRageRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        rage = 100;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private float jumpPower = 10;

    [SerializeField] private float rage = 0f;
    [SerializeField] private bool enrage = false;
    [SerializeField] private float subtractRage = 1f;
    [SerializeField] public bool boolRage;
    [SerializeField] public bool stopActions = false;

    [SerializeField] private bool hasClub = false;
    [SerializeField] private bool clubCinematic = true;

    [SerializeField] private bool freeGammyBool = true;
    [SerializeField] private bool teachRageBool = true;
    [SerializeField] private bool rageTutorial;
    [SerializeField] private bool chestOpened = false;
    [SerializeField] private int rageTutorialCollect = 0;

    private PlayerAnimation _anim;
    private SpriteRenderer _spriteR;
    private CanvasManager _canvas;
    private DialogTrigger _dt;
    private SceneSelector _scene;

    [SerializeField] private Transform gammieTransform;

    PlayerAudioStorage audioStorage;
    [SerializeField] private float _sfxVolume = 1.0f;

    public Image rageBar;
    private float _rageFull = 100;
    [SerializeField] private Vector2 rageBarOrigSize;
    [SerializeField] private float percentRage;

    [SerializeField] private int _hp = 3;
    public Animator heart1;
    public Animator heart2;
    public Animator heart3;

    private bool _initialSwim = true;
    private bool _isSwimming = false;
    public bool _dbOn = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<PlayerAnimation>();
        _spriteR = GetComponentInChildren<SpriteRenderer>();
        _dt = GetComponent<DialogTrigger>();
        _canvas = GameObject.Find("Canvas").GetComponent<CanvasManager>();
        rageBar = GameObject.Find("RageBarFill").GetComponent<Image>();
        _scene = GetComponentInChildren<SceneSelector>();

        audioStorage = GetComponent<PlayerAudioStorage>();

        audioStorage = GetComponent<PlayerAudioStorage>();

        heart1 = GameObject.Find("Heart_1").GetComponent<Animator>();
        heart2 = GameObject.Find("Heart_2").GetComponent<Animator>();
        heart3 = GameObject.Find("Heart_3").GetComponent<Animator>();

        rageBarOrigSize = rageBar.rectTransform.sizeDelta;
        rage = 0;

        if (_canvas == null)
        {
            Debug.LogError("The Canvas is NULL");
        }

        _dt.TriggerDialog();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateRage();
        FreeGammyCutScene();
        triggerWaterScene();

        UpdateUI();
        row();
        if (stopActions == false || _dbOn == false)
        {
            if (Input.GetButtonDown("Fire1") && hasClub == true && _isSwimming == false)
            {
                _anim.Attack();

                int randSound = Random.Range(1, 3);
                switch (randSound)
                {
                    case 1:
                        PlayAudio(audioStorage._woosh_1, 1.0f);
                        break;
                    case 2:
                        PlayAudio(audioStorage._woosh_2, 1.0f);
                        break;
                    default:
                        print("Randomizer selected a non-existant sound option.");
                        break;
                      
                }
            }
            maxSpeed = 5;
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
            if (hasClub == true && clubCinematic == true)
            {
                _scene.FoundClub();
                clubCinematic = false;
            }
        }

        if(_dbOn)
        {
            targetVelocity = new Vector2(Input.GetAxis("Horizontal") * 0, 0);
            _anim.Idle(0);
            stopActions = true;
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
        yield return new WaitForSeconds(.5f);
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water") && _initialSwim == true)
        {
            stopActions = true;
            _anim.Swim();
            StartCoroutine(StartSwimRoutine());
        }
        if (other.CompareTag("EndSceneTrigger"))
        {
            _scene.EndScene();
        }
        if (other.CompareTag("RageCollectible"))
        {
            rageTutorialCollect += 1;
        }
    }
    IEnumerator StartSwimRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        _initialSwim = false;
        stopActions = false;
        _isSwimming = true;
    }
    private void row()
    {
        if (_isSwimming == true)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
            {
                _anim.Row(true);
            }
            else
            {
                _anim.Row(false);
            }
        }
    }

    private void FreeGammyCutScene()
    {
        float dist = Vector3.Distance(transform.position, gammieTransform.position);
        if (dist < 2.0f && freeGammyBool == true)
        {
            StartCoroutine(FreeGammyRoutine());
            freeGammyBool = false;
        }
    }
    IEnumerator FreeGammyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        _scene.FreeGammyScene();
    }
    public void TeachBromRage()
    {
        if (teachRageBool == true)
        {
            StartCoroutine(TeachBromRageRoutine());
            //StartCoroutine(WaterSceneRoutine());
        }
    }
    IEnumerator TeachBromRageRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        rage = 100;
        rageTutorial = true;
        teachRageBool = false;
    }
    IEnumerator WaterSceneRoutine()
    {
        //Just a temporary trigger for the cinematic
        yield return new WaitForSeconds(5.0f);
        _scene.WaterScene();
    }

    public void UpdateUI()
    {
        percentRage = rage / _rageFull;
        rageBar.rectTransform.sizeDelta = new Vector2(percentRage * rageBarOrigSize.x, rageBar.rectTransform.sizeDelta.y);

        if (_hp == 3)
        {
            heart1.SetBool("Empty", false);
            heart2.SetBool("Empty", false);
            heart3.SetBool("Empty", false);
        }
        else if (_hp == 2)
        {
            heart1.SetBool("Empty", false);
            heart2.SetBool("Empty", false);
            heart3.SetBool("Empty", true);
        }
        else if (_hp == 1)
        {
            heart1.SetBool("Empty", false);
            heart2.SetBool("Empty", true);
            heart3.SetBool("Empty", true);
        }
        else
        {
            heart1.SetBool("Empty", true);
            heart2.SetBool("Empty", true);
            heart3.SetBool("Empty", true);
        }
    }
    private void PlayAudio(AudioClip _soundFX, float _sfxVolume)
    {
        if (_soundFX != null)
        {
            AudioManager.Instance.PlayEffect(_soundFX, _sfxVolume);
        }
    }
    public void RageCollected()
    {
        rage += 20;
    }
    public void rageTutorialChest()
    {
        if (rageTutorial == true)
        {
            chestOpened = true;
        }   
    }
    public void triggerWaterScene()
    {
        if (rageTutorialCollect == 5 && chestOpened == true && rageTutorial == true)
        {
            _scene.WaterScene();
            rageTutorial = false;
        }
    }
}

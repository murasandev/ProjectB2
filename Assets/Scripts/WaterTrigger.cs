using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private Animator _water;
    private AudioManager _audioManager;

    [SerializeField] private AudioClip _waterSfx;
    [SerializeField] private float _sfxVol;
    [SerializeField] private bool _loopOn;

    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.Instance;
        _water = GetComponent<Animator>();
        _sfxVol = 5.0f;
        _loopOn = true;
    }
    public void WaterTriggerStart()
    {
        _water.SetTrigger("WaterRise");
        _audioManager.LoopEffectStart(_waterSfx, _sfxVol, _loopOn);
    }
}

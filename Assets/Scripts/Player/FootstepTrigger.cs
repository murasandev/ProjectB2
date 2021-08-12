using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepTrigger : MonoBehaviour
{

    PlayerAudioStorage audioStorage;
    // Start is called before the first frame update
    void Start()
    {
        audioStorage = GetComponent<PlayerAudioStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayAudio(AudioClip _soundFX, float _sfxVolume)
    {
        if (_soundFX != null)
        {
            AudioManager.Instance.PlayEffect(_soundFX, _sfxVolume);
        }
    }
}

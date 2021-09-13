using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepOne : MonoBehaviour
{
    //PlayerAudioStorage audioStorage;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerAudioStorage audioStorage = GetComponent<PlayerAudioStorage>();

        //PlayAudio(audioStorage._footstep_1, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootstepOne()
    {
        PlayerAudioStorage audioStorage = GetComponent<PlayerAudioStorage>();

        AudioManager.Instance.PlayEffect(audioStorage._footstep_1, 0.15f);
    }
}

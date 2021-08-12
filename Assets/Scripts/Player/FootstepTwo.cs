using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepTwo : MonoBehaviour
{

    //PlayerAudioStorage audioStorage;

    // Start is called before the first frame update
    void Start()
    {
        //audioStorage = GetComponent<PlayerAudioStorage>();

        //PlayAudio(audioStorage._footstep_2, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayFootStepTwo()
    {

        PlayerAudioStorage audioStorage = GetComponent<PlayerAudioStorage>();

        if (audioStorage != null)
        {
            print(audioStorage);
        }
        AudioManager.Instance.PlayEffect(audioStorage._footstep_2, 0.5f);
    }
}

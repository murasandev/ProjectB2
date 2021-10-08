using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonOn;

    [SerializeField] private AudioClip _buttonOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySwitchOn()
    {
        AudioManager.Instance.PlayEffect(_buttonOn, 0.15f);
    }


    public void PlaySwitchOff()
    {
        AudioManager.Instance.PlayEffect(_buttonOff, 0.15f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    [SerializeField]
    private AudioSource _sfxSource;
    [SerializeField]
    private AudioSource _bgmSource;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeMusic()
    {
        _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        StartCoroutine(FadeMusicOut(_bgmSource, 80.5f, 0.0f));
    }


    IEnumerator FadeMusicOut(AudioSource audioMixer, float duration, float targetVolume)
    {
        float currentTime = 0;

        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(_bgmSource.volume, targetVolume, currentTime / duration);

            print("new vol");
            print(newVol);

            _bgmSource.volume = newVol;

            yield return null;
        }

        yield break;
    }
}

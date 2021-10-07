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

    [SerializeField]
    private AudioSource _bgmSource_2;

    [SerializeField]
    private int _fadeType;

    [SerializeField]
    private float _fadeTime;

    [SerializeField]
    private float _targetVol;

    [SerializeField]
    private float _targetVol_2;

    // Start is called before the first frame update
    void Start()
    {
        if (_fadeType > 0 && _fadeType < 3)
        {
            FadeAudio(_fadeTime, _targetVol, _targetVol_2, _fadeType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeAudio(float fadeTime, float targetVol, float targetVol_2, int _fadeType)
    {
        _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        _bgmSource_2 = GameObject.Find("BGM_2").GetComponent<AudioSource>();

        switch (_fadeType)
        {
            case 1:
                StartCoroutine(FadeOut(_bgmSource, fadeTime, targetVol));
                break;

            case 2:
                StartCoroutine(FadeIn(_bgmSource, fadeTime, targetVol));
                break;

            case 3:
                StartCoroutine(CrossFade(_bgmSource, _bgmSource_2, fadeTime, targetVol, targetVol_2));
                break;

            default:
                print("No fade type given");
                break;
        }
    }


    public void FadeOutAuto(int _audioSource)
    {
        if (_audioSource == 1)
        {
            _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
            _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
            print("Fade Time: " + _fadeTime);
            StartCoroutine(FadeOut(_bgmSource, _fadeTime, 0.0f));
        }

        else if (_audioSource == 2)
        {
            _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
            _bgmSource_2 = GameObject.Find("BGM_2").GetComponent<AudioSource>();
            print("Fade Time for audioSource 2: " + _fadeTime);
            StartCoroutine(FadeOut(_bgmSource_2, _fadeTime, 0.0f));
        }
    }

    public void FadeInAuto(int _audioSource)
    {
        if (_audioSource == 1)
        {
            _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
            _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
            StartCoroutine(FadeIn(_bgmSource, _fadeTime, 0.3f));
        }

        else if (_audioSource == 2)
        {
            _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
            _bgmSource_2 = GameObject.Find("BGM_2").GetComponent<AudioSource>();
            StartCoroutine(FadeIn(_bgmSource_2, _fadeTime, 0.3f));
        }

    }



    IEnumerator FadeOut(AudioSource audioMixer, float duration, float targetVolume)
    {
        float currentTime = 0;

        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(audioMixer.volume, targetVolume, currentTime / duration);


            audioMixer.volume = newVol;

            yield return null;
        }

        yield break;
    }

    IEnumerator FadeIn(AudioSource audioMixer, float duration, float targetVol)
    {
        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(0, targetVol, currentTime / duration);

            audioMixer.volume = newVol;

            yield return null;
        }

        yield break;
    }

    IEnumerator CrossFade(AudioSource audioMixer_1, AudioSource audioMixer_2, float duration, float targetVol_1, float targetVol_2)
    {

        float currentTime = 0;

        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol_1 = Mathf.Lerp(audioMixer_1.volume, targetVol_1, currentTime / duration);
            float newVol_2 = Mathf.Lerp(audioMixer_2.volume, targetVol_2, currentTime / duration);

            audioMixer_1.volume = newVol_1;
            audioMixer_2.volume = newVol_2;

            yield return null;

        }
        yield break;
    }
}

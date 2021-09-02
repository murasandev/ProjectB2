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
    private int _fadeType;

    [SerializeField]
    private float _fadeTime;

    [SerializeField]
    private float _targetVol;

    // Start is called before the first frame update
    void Start()
    {
        if (_fadeType > 0 && _fadeType < 3)
        {
            FadeAudio(_fadeTime, _targetVol, _fadeType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeAudio(float fadeTime, float targetVol, int _fadeType)
    {
        _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();

        switch (_fadeType)
        {
            case 1:
                StartCoroutine(FadeOut(_bgmSource, fadeTime, targetVol));
                break;

            case 2:
                StartCoroutine(FadeIn(_bgmSource, fadeTime, targetVol));
                break;

            default:
                print("No fade type given");
                break;
        }
    }


    public void FadeOutAuto()
    {
        _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        StartCoroutine(FadeOut(_bgmSource, 80.5f, 0.0f));
    }

    public void FadeInAuto()
    {
        _sfxSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        StartCoroutine(FadeIn(_bgmSource, 80.5f, 0.0f));
    }


    IEnumerator FadeOut(AudioSource audioMixer, float duration, float targetVolume)
    {
        float currentTime = 0;

        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(_bgmSource.volume, targetVolume, currentTime / duration);


            _bgmSource.volume = newVol;

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

            _bgmSource.volume = newVol;

            yield return null;
        }

        yield break;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{

    [SerializeField] private GameObject _sceneAudio;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SwitchTrack()
    {
        SceneAudio _audioPlayer = _sceneAudio.GetComponent<SceneAudio>();
        MusicFader _crossFade = GetComponent<MusicFader>();

        int _trackId_1 = _audioPlayer._trackId_1;
        int _trackId_2 = _audioPlayer._trackId_2;
        float _source_vol_1 = _audioPlayer._source_volume_1;
        float _source_vol_2 = _audioPlayer._source_volume_2;

        int currentSource = _audioPlayer._audioSource;

        if (currentSource == 1)
        {
            _audioPlayer.SelectTrack(_trackId_2, 2, _source_vol_2);

            _crossFade.FadeAudio(80.5f, _source_vol_2, _source_vol_1, 3);

            _audioPlayer._audioSource = 2;
        }
        else if( currentSource == 2)
        {
            _audioPlayer.SelectTrack(_trackId_1, 1, _source_vol_1);
            _crossFade.FadeAudio(80.5f, _source_vol_1, _source_vol_2, 3);

            _audioPlayer._audioSource = 1;
        }
    }
}

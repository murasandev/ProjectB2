using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
   [SerializeField]
    public float _source_volume_1 = 1.0f;

    [SerializeField]
    public float _source_volume_2 = 1.0f;

    [SerializeField]
    public int _trackId_1;

    [SerializeField]
    public int _trackId_2;

    [SerializeField]
    private bool _playOnStart;

    [SerializeField]
    public int _audioSource;

    SceneMusicStorage sceneMusic;


    // Start is called before the first frame update
    void Start()
    {
        sceneMusic = GetComponent<SceneMusicStorage>();

        if(_playOnStart == true)
        {
            if (_audioSource == 1)
            {
                AudioManager.Instance.PlayMusic(MusicSelection(_trackId_1), _source_volume_1, _audioSource);
            }

            else if(_audioSource == 2)
            {
                AudioManager.Instance.PlayMusic(MusicSelection(_trackId_2), _source_volume_2, _audioSource);
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private AudioClip MusicSelection(int _trackId)
    {
        AudioClip _musicTrack;
        
        if(_trackId > 5)
        {
            _musicTrack = null;
        }
        else
        {
            switch (_trackId)
            {
                case 1:
                    _musicTrack = sceneMusic._track_1;
                    break;
                case 2:
                    _musicTrack = sceneMusic._track_2;
                    break;
                case 3:
                    _musicTrack = sceneMusic._track_3;
                    break;
                case 4:
                    _musicTrack = sceneMusic._track_4;
                    break;
                case 5:
                    _musicTrack = sceneMusic._track_5;
                    break;
                default:
                    _musicTrack = null;
                    break;
            }
        }
        return _musicTrack;
            
    }

   
    public void SelectTrack(int _trackInput, int _source, float _volume)
    {
        AudioClip _musicTrack;
        print("input: " + _trackInput);
        print("volume: " + _volume);
        if (_trackInput > 5)
        {
            _musicTrack = null;
        }
        else
        {
            switch (_trackInput)
            {
                case 1:
                    _musicTrack = sceneMusic._track_1;
                    break;
                case 2:
                    _musicTrack = sceneMusic._track_2;
                    break;
                case 3:
                    _musicTrack = sceneMusic._track_3;
                    break;
                case 4:
                    _musicTrack = sceneMusic._track_4;
                    break;
                case 5:
                    _musicTrack = sceneMusic._track_5;
                    break;
                default:
                    _musicTrack = null;
                    break;
            }
        }
        print("Music Track: " + _musicTrack);
        AudioManager.Instance.PlayMusic(_musicTrack, _volume, _source);

    }

}

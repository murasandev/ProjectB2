using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
   [SerializeField]
    private float _volume = 1.0f;

    [SerializeField]
    private int _trackId;

    SceneMusicStorage sceneMusic;


    // Start is called before the first frame update
    void Start()
    {
        sceneMusic = GetComponent<SceneMusicStorage>();
        AudioManager.Instance.PlayMusic(MusicSelection(_trackId), _volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private AudioClip MusicSelection(int _trackId)
    {
        AudioClip _musicTrack;
        
        if(_trackId > 4)
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
                default:
                    _musicTrack = null;
                    break;
            }
        }
        return _musicTrack;
            
    }

}

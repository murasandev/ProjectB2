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

    public void SelectTrack(int _trackId)
    {
        SceneAudio _audioPlayer = _sceneAudio.GetComponent<SceneAudio>();

        _audioPlayer.SelectTrack(_trackId);

    }
}

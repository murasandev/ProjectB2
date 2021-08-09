using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudio : MonoBehaviour
{
   [SerializeField]
    private float _volume = 1.0f;

    SceneMusicStorage sceneMusic;


    // Start is called before the first frame update
    void Start()
    {
        sceneMusic = GetComponent<SceneMusicStorage>();
        AudioManager.Instance.PlayMusic(sceneMusic._track_1, _volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

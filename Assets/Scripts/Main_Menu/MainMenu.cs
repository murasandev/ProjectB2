using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private AudioMixer _audioMixer;

    [SerializeField]
    private AudioClip _menuMusic;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(_menuMusic, 1f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

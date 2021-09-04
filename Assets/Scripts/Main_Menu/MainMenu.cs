using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private AudioMixer _audioMixer;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject fader;

    //private CanvasGroup canvasGroup;

    private void Start()
    {
        //canvasGroup = GetComponent<CanvasGroup>();
        //canvasGroup.interactable = false;
    }

    public void StartGame()
    {
        fader.SetActive(true);

        Animator fadeAnim = fader.GetComponent<Animator>();

        fadeAnim.SetTrigger("LoadScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(7);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    private Canvas _canvas;
    private NewPlayer _player;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _player = FindObjectOfType<NewPlayer>();
    }
    public void IntroComplete()
    {
        SceneManager.LoadScene(2);
    }
    public void FoundClub()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        _canvas.enabled = false;
    }
    public void UnloadClubScene()
    {
        SceneManager.UnloadSceneAsync(3);
        _canvas.enabled = true;
    }
    public void FreeGammyScene()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
        _canvas.enabled = false;
    }
    public void UnloadFreeGammy()
    {
        SceneManager.UnloadSceneAsync(4);
        _canvas.enabled = true;
        _player.TeachBromRage();
    }
}

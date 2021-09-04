using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    private Canvas _canvas;
    private NewPlayer _player;
    private Gammie _gammie;
    private WaterTrigger _water;
    private EndTrigger _endTrigger;
    private TutorialRage _tutorialRage;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _player = FindObjectOfType<NewPlayer>();
        _gammie = FindObjectOfType<Gammie>();
        _water = FindObjectOfType<WaterTrigger>();
        _endTrigger = FindObjectOfType<EndTrigger>();
        _tutorialRage = FindObjectOfType<TutorialRage>();
    }
    public void IntroComplete()
    {
        SceneManager.LoadScene(2);
    }
    public void FoundClub()
    {
        SceneManager.LoadScene(8, LoadSceneMode.Additive);
        _canvas.enabled = false;
        _player.enabled = false;
    }
    public void UnloadClubScene()
    {
        SceneManager.UnloadSceneAsync(8);
        _canvas.enabled = true;
        _player.enabled = true;
    }
    public void FreeGammyScene()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
        _canvas.enabled = false;
        _player.enabled = false;
    }
    public void UnloadFreeGammy()
    {
        SceneManager.UnloadSceneAsync(4);
        _canvas.enabled = true;
        _player.TeachBromRage();
        _gammie.TransformtoDrake();
        _tutorialRage.startTutorialRage();
        _player.enabled = true;
    }
    public void WaterScene()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
        _canvas.enabled = false;
        _player.enabled = false;
    }
    public void UnloadWaterScene()
    {
        SceneManager.UnloadSceneAsync(5);
        _canvas.enabled = true;
        _water.WaterTriggerStart();
        _endTrigger.EndTriggerEnable();
        _player.enabled = true;
    }
    public void EndScene()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
        _canvas.enabled = false;
        _player.enabled = false;
    }
}

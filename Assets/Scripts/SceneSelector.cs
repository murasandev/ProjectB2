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
    private EventManager _eventManager;
    private BjornArmActivate _bjornActivate;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        _player = FindObjectOfType<NewPlayer>();
        _gammie = FindObjectOfType<Gammie>();
        _water = FindObjectOfType<WaterTrigger>();
        _endTrigger = FindObjectOfType<EndTrigger>();
        _tutorialRage = FindObjectOfType<TutorialRage>();
        _bjornActivate = FindObjectOfType<BjornArmActivate>();

        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is NULL");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(10, LoadSceneMode.Additive);
        _canvas.enabled = false;
        _player.enabled = false;
    }
    public void UnloadFreeGammy()
    {
        SceneManager.UnloadSceneAsync(10);
        _canvas.enabled = true;
        _eventManager.FreeGammieSceneActivated();
        _player.TeachBromRage();
        _gammie.TransformtoDrake();
        _tutorialRage.startTutorialRage();
        _player.enabled = true;
    }
    public void WaterScene()
    {
        SceneManager.LoadScene(11, LoadSceneMode.Additive);
        _canvas.enabled = false;
        _player.enabled = false;
    }
    public void UnloadWaterScene()
    {
        SceneManager.UnloadSceneAsync(11);
        _canvas.enabled = true;
        _water.WaterTriggerStart();
        _bjornActivate.ActivateBjorn();
        _player.enabled = true;
        _eventManager.WaterSceneActivated();
    }
    public void EndScene()
    {
        SceneManager.LoadScene(12, LoadSceneMode.Additive);
        AudioManager.Instance.LoopEffectStop();
        _canvas.enabled = false;
        _player.enabled = false;
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(9);
    }
}

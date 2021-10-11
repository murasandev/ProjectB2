using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{

    private DialogTrigger _dt;
    private EventManager _eventManager;
    [SerializeField] private Dialog _clubFoundDialog;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private float _sfxVol;
    [SerializeField] private GameObject _skeletonCrushDT;

    // Start is called before the first frame update
    void Start()
    {
        _dt = GetComponent<DialogTrigger>();


        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _eventManager.ClubFound += ClubFound;
        _eventManager.StartGammieScene += TurnOffDialog;
        _skeletonCrushDT.SetActive(false);

        _sfxVol = 1.0f;
    }

    public void ClubFound() => _dt.dialog = _clubFoundDialog;

    public void TurnOffDialog() => _dt.TurnOffDialogTrigger();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int helpLvl = 6;
            _eventManager.UpdateHelpText(helpLvl);       
        }

        if(other.CompareTag("Bird Cage"))
        {
            PlayAudio(_hitSound, _sfxVol);
            _skeletonCrushDT.SetActive(true);
        }
    }

    private void PlayAudio(AudioClip _soundFX, float _sfxVolume)
    {
        if (_soundFX != null)
        {
            AudioManager.Instance.PlayEffect(_soundFX, _sfxVolume);
        }
    }

    private void OnDestroy()
    {
        _eventManager.ClubFound -= ClubFound;
        _eventManager.StartGammieScene -= TurnOffDialog;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _objects;

    [SerializeField]
    public GameObject _dialogbox;

    [SerializeField]
    private Text _helpText;

    private DialogController _dialogController;
    private bool _dbActive;
    private bool _helpBoxActive;
    public Image helpBox;

    void Start()
    {
        _dialogbox.SetActive(false);
        _dbActive = true;
        _dialogController = FindObjectOfType<DialogController>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitNovelPanel();
        }

        CloseHelpBox();
        OpenHelpBox();
        ShowHelpText();
    }

    public void NovelPanelActive()
    {
        _objects[0].SetActive(true);
    }

    public void ExitNovelPanel()
    {
        _objects[0].SetActive(false);
    }

    public void ShowHelpText()
    {
        if (!_dbActive && !_helpBoxActive)
        {
            _helpText.gameObject.SetActive(true);
        }
        else
        {
            HideHelpText();
        }       
    }

    public void HideHelpText()
    {
        _helpText.gameObject.SetActive(false);
    }

    public void ShowDialogBox(bool isDbActive)
    {
        _dialogbox.SetActive(isDbActive);
        _dbActive = isDbActive;
        
    }

    private void OpenHelpBox()
    {
        if (Input.GetKeyDown(KeyCode.X) && !_dbActive)
        {
            helpBox.gameObject.SetActive(true);
            _helpBoxActive = true;
        }
    }

    private void CloseHelpBox()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            helpBox.gameObject.SetActive(false);
            _helpBoxActive = false;
        }     
    }
}

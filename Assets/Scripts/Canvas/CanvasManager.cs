using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _objects;

    [SerializeField]
    private GameObject _dialogbox;

    [SerializeField]
    private Text _helpText;

    void Start()
    {
        _dialogbox.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitNovelPanel();
        }
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
        _helpText.enabled = true;
    }

    public void HideHelpText()
    {
        _helpText.enabled = false;
    }

    public void ShowDialogBox(bool isDbActive)
    {
        _dialogbox.SetActive(isDbActive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _novelPanel;
    [SerializeField]
    private Text _helpText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitNovelPanel();
        }
    }

    public void NovelPanelActive()
    {
        _novelPanel.SetActive(true);
    }

    public void ExitNovelPanel()
    {
        _novelPanel.SetActive(false);
    }

    public void ShowHelpText()
    {
        _helpText.enabled = true;
    }

    public void HideHelpText()
    {
        _helpText.enabled = false;
    }
}

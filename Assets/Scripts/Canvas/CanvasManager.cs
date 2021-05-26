using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _objects;

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
}

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
    public Image helpBox;

    void Start()
    {
        _dialogbox.SetActive(false);
        _dialogController = FindObjectOfType<DialogController>();
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    //ExitNovelPanel();
        //    CloseHelpBox();
        //}
        CloseHelpBox();
        OpenHelpBox();
        
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

    private void OpenHelpBox()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            helpBox.gameObject.SetActive(true);
            HideHelpText();
        }
           

    }

    private void CloseHelpBox()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            helpBox.gameObject.SetActive(false);
            ShowHelpText();
        }
            
    }
}

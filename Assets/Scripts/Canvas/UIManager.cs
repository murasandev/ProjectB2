using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _dialogbox;
   

    // Start is called before the first frame update
    void Start()
    {
        _dialogbox.SetActive(false);
    }


    public void ShowDialogBox(bool isDbActive)
    {
        _dialogbox.SetActive(isDbActive);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EventManager : MonoBehaviour
{

    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }


    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }

        _instance = this;
    }

    
    public event Action<int> NewHelpText;
    public void UpdateHelpText(int helpTxtNum)
    {
        if (NewHelpText != null)
            NewHelpText(helpTxtNum);
    }


    public event Action ClubFound;
    public void FoundClub()
    {
        if (ClubFound != null)
            ClubFound();
    }

   }


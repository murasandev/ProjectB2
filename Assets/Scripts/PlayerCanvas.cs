using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{

    [SerializeField]
    public GameObject _EtoInteract;

    private void Update()
    {
        
    }


    public void EtoInteractIsActive(bool isActive) => _EtoInteract.gameObject.SetActive(isActive);
}

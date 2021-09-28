using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtoInteract : MonoBehaviour
{
    [SerializeField]
    public GameObject _EtoInteract;


    public void EtoInteractIsActive(bool isActive) => _EtoInteract.gameObject.SetActive(isActive);
}

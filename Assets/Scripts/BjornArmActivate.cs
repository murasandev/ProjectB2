using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BjornArmActivate : MonoBehaviour
{
    [SerializeField] private bool actBjorn;
    private void Update()
    {
        if (actBjorn == true)
        {
            ActivateBjorn();
        }
    }
    public void ActivateBjorn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
    }
}

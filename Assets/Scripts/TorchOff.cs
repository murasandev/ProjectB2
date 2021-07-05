using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOff : MonoBehaviour
{
    [SerializeField] private GameObject lighting;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            this.gameObject.SetActive(false);
            lighting.SetActive(false);
        }
    }
}

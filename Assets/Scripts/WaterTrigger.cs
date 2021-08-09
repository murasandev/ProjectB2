using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private Animator _water;

    // Start is called before the first frame update
    void Start()
    {
        _water = GetComponent<Animator>();
    }
    public void WaterTriggerStart()
    {
        _water.SetTrigger("WaterRise");
    }
}

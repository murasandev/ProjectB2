using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageFall : MonoBehaviour
{
    public EventManager _eventManager; 
    
    // Start is called before the first frame update
    void Start()
    {
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();

        if (_eventManager == null)
            Debug.Log("Event Manager is NULL");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider other)
    {
        
    }
}

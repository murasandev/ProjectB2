using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BjornDialog : MonoBehaviour
{

    private EventManager _eventManager;
    private BoxCollider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        
        _eventManager = EventManager.Instance != null ? EventManager.Instance : FindObjectOfType<EventManager>();
        if (_eventManager == null)
            Debug.Log("Event Manager is null");

        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;

        _eventManager.WaterSceneActive += ColliderOn;
    }

    public void ColliderOn() => _collider.enabled = true;

    private void OnDestroy() => _eventManager.WaterSceneActive -= ColliderOn;
}

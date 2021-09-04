using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private BoxCollider2D _endCollider;

    private void Start()
    {
        _endCollider = GetComponent<BoxCollider2D>();
    }
    public void EndTriggerEnable()
    {
        _endCollider.enabled = true;
    }
}

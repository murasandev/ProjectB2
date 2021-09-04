using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _cameraSpeed = .2f;
    [SerializeField]
    private float _xOffset, _yOffset;
    private Vector2 _newPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _newPos = new Vector2(_target.position.x + _xOffset, _target.position.y + _yOffset);
        transform.position = Vector2.Lerp(transform.position, _newPos, _cameraSpeed * Time.deltaTime);
    }
}

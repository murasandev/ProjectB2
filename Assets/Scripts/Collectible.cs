using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _bc;
    [SerializeField] private Rigidbody2D _rb;

    Vector3 lastPosition = Vector3.zero;
    private float _speed;

    // Start is called before the first frame update
    private void Start()
    {
        //reference player rage
        _bc = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Speed();
        Debug.Log(_speed + " Speed");
        if (_speed == 0.0f)
        {
            DisableMass();
            EnableTrigger();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //add rage to player rage
            Destroy(this.gameObject);
        }
    }
    private void EnableTrigger()
    {
        _bc.isTrigger = enabled;   
    }
    private void DisableMass()
    {
        _rb.mass = 0.0f;
        _rb.gravityScale = 0.0f;
    }
    private void Speed()
    {
        _speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }
}

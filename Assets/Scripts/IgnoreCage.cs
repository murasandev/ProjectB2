using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCage : MonoBehaviour
{
    private CapsuleCollider2D _birdCageCollider2D;
    private Collider2D _playerCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        _birdCageCollider2D = GameObject.FindGameObjectWithTag("Bird Cage").GetComponent<CapsuleCollider2D>();
        _playerCollider2D = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(_playerCollider2D, _birdCageCollider2D);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

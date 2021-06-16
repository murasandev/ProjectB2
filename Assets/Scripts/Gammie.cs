using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gammie : MonoBehaviour
{
    [SerializeField] private bool cageFree = false;
    [SerializeField] private bool movetoPlayer = false;

    private Animator _anim;

    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private Transform position;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bird Cage") && cageFree == false)
        {
            cageFree = true;
            _anim.SetTrigger("toGammie");
            movetoPlayer = true;
        }
    }
    private void Movement()
    {
        if (movetoPlayer == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, target.position, step);

            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}

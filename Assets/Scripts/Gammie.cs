using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gammie : MonoBehaviour
{
    [SerializeField] private bool cageFree = false;
    [SerializeField] private bool movetoPlayer = false;
    [SerializeField] private bool transformGammie = true;

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
        TransformtoGammie();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bird Cage") && cageFree == false)
        {
            cageFree = true;
            
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
    private void TransformtoGammie()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist < 1.0f && transformGammie == true)
        {
            _anim.SetTrigger("toGammie");
            transformGammie = false;
        }
    }
}

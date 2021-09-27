using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicViewer : MonoBehaviour
{

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();

        if(_anim == null)
        {
            Debug.LogError("The animator is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TurnPage();
    }

    void TurnPage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("OnLeftClick");
            _anim.ResetTrigger("OnRightClick");

            StartCoroutine(ResetInput());
        }

        if (Input.GetMouseButtonDown(1))
        {
            _anim.SetTrigger("OnRightClick");
            _anim.ResetTrigger("OnLeftClick");
            StartCoroutine(ResetInput());
        }

        /*
        if (this._anim.GetCurrentAnimatorStateInfo(0).IsName("Page_1_Panel_2"))
        {
            Debug.Log("State 2 done");
        } */

    }

    // CoRoutine to reset the users input every fraction of a second to remove lingering inputs when performed during periods where 
    // transitions cannot occur.
    public IEnumerator ResetInput()
    {
        yield return new WaitForSeconds(0.1f);
        _anim.ResetTrigger("OnLeftClick");
        _anim.ResetTrigger("OnRightClick");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinPromptCtrl : MonoBehaviour
{
    [SerializeField] Image cont_Prompt;
    [SerializeField] Image prev_Prompt;

    private int prompt_Ready;

    // Start is called before the first frame update
    void Start()
    {
        prompt_Ready = 0;
        Color prompt_Color = cont_Prompt.color;
        prompt_Color.a = 0.0f;
        cont_Prompt.color = prompt_Color;
        prev_Prompt.color = prompt_Color;


    }

    // Update is called once per frame
    void Update()
    {
        PlayerClick();
    }

    void PlayerClick()
    {
        if (prompt_Ready == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Color prompt_Color = cont_Prompt.color;
                prompt_Color.a = 1.0f;
                cont_Prompt.color = prompt_Color;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Color R_prompt_Color = cont_Prompt.color;
                R_prompt_Color.a = 0.922f;
                cont_Prompt.color = R_prompt_Color;
            }

            if (Input.GetMouseButtonDown(1))
            {
                Color L_prompt_Color = prev_Prompt.color;
                L_prompt_Color.a = 1.0f;
                prev_Prompt.color = L_prompt_Color;
            }

            if (Input.GetMouseButtonUp(1))
            {
                Color L_prompt_Color = prev_Prompt.color;
                L_prompt_Color.a = 0.922f;
                prev_Prompt.color = L_prompt_Color;
            }

        }
       

    }

    public void RevealPromptsFade(int prompt_ready)
    {
        StartCoroutine(FadeIn(0.922f, 1.0f));
        prompt_Ready = 1;
    }

    public void RevealPromptsNoFade(int prompt_ready)
    {   
       Color prompt_Color = cont_Prompt.color;
       prompt_Color.a = 0.922f;
       cont_Prompt.color = prompt_Color;
       prev_Prompt.color = prompt_Color;
      
       prompt_Ready = 1;
    }

    IEnumerator FadeIn(float aVal, float dur)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / dur)
        {
            Color newOpacity = new Color(1, 1, 1, Mathf.Lerp(0, aVal, t));
            cont_Prompt.color = newOpacity;
            prev_Prompt.color = newOpacity;
            yield return null;
        }
    }

    public int PromptReady(int prompt_Ready)
    {
        prompt_Ready = 1;

        return prompt_Ready;
    }


}

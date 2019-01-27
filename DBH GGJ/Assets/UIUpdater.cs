using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public Text dialogueText;
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;

    /// for type writer effect
    public float TyperDelay = 0.01f;
   



    private GameState gs;
    private GraphPos gp;

    private void Start()
    {
        gs = GetComponent<GameState>();
        gp = GetComponent<GraphPos>();
        updateAll();
        
        
    }


    IEnumerator Typer(string input) {
       // Debug.Log(input.Substring(0, input.Length-1));
        for (int i = 0; i <= input.Length; i++)
        {
            dialogueText.text = input.Substring(0, i);
            yield return new WaitForSeconds(TyperDelay);
        }

    }

    //long text
    public void dialogueUpdate(string input)
    {
        StartCoroutine(Typer(input));
      //  dialogueText.text = input;
    }

//short text
    public void optionUpdate(string input, int optionNumber)
    {
        //if input is empty give a default value
        input = (input == "") ? "..." : input;
        //enable as well to ensure changes are visible
        if(optionNumber==1)
        {
            option1Text.transform.parent.gameObject.SetActive(true);
            option1Text.text = input;
        }
        else if (optionNumber == 2)
        {
            option2Text.transform.parent.gameObject.SetActive(true);
            option2Text.text = input;
        }
        else if (optionNumber == 3)
        {
            option3Text.transform.parent.gameObject.SetActive(true);
            option3Text.text = input;
        }
    }

    public void updateAll()
    {
        Dialogue dialogue = gp.getCurrentDialogue();
        //longtext
        dialogueUpdate(dialogue.longText);
        //disable all buttons to clear screen
        option1Text.transform.parent.gameObject.SetActive(false);
        option2Text.transform.parent.gameObject.SetActive(false);
        option3Text.transform.parent.gameObject.SetActive(false);
        //shorttext
        for (int i = 0; i < dialogue.options.Count; ++i)
        {
            optionUpdate(gp.graph[dialogue.options[i]].shortText, i + 1);
        }
        //stress
        gs.UpdateStress(dialogue.stressCost);
        //timer
        gs.SetMaxTimer(dialogue.maxTimer, dialogue.maxStressTimePenalty);
        //portraitTransitions
        if(dialogue.speaker == "Gavin")
        {
            gs.SetGavPortrait(dialogue.portraitTransitions[0]);
        }
        else
        {
            gs.SetPerpPortrait(dialogue.portraitTransitions[0]);
        }
    }
}

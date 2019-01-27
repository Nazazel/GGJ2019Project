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

    private GraphPos gp;

    private void Start()
    {
        gp = GetComponent<GraphPos>();
        updateAll();
    }

    //long text
    public void dialogueUpdate(string input)
    {
        dialogueText.text = input;
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
    }


}

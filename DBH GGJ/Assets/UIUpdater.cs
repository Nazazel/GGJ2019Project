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
    public AudioClip GavBlip;
    /// for type writer effect
    public float TyperDelay = 0.01f;
   



    private GameState gs;
    private GraphPos gp;
    private AudioSource AS;
    private bool MakeSounds;
    private void Start()
    {
        gs = GetComponent<GameState>();
        gp = GetComponent<GraphPos>();
        AS = GetComponent<AudioSource>();
        updateAll();
        MakeSounds = false;


    }

    IEnumerator musicPlayer()
    {

        while (MakeSounds == true) {
            AS.PlayOneShot(GavBlip);
            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator Typer(string input) {
        AS.volume = 1;
        // Debug.Log(input.Substring(0, input.Length-1));
        MakeSounds = true;
        for (int i = 0; i <= input.Length; i++)
        {
            dialogueText.text = input.Substring(0, i);
            yield return new WaitForSeconds(TyperDelay);
        }
        MakeSounds = false;
        AS.volume = 0;

    }

    //long text
    public void dialogueUpdate(string input)
    {
        StartCoroutine(Typer(input));
        StartCoroutine(musicPlayer());

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

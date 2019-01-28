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
    public AudioClip PerpBlip;
    
    /// for type writer effect
    public float TyperDelay = 0.01f;



    string speaker;
    private AudioClip speakerAudio;
    private GameState gs;
    private GraphPos gp;
    private AudioSource AS;
    private bool MakeSounds;
    private Coroutine activeTyper, activeSpeaker;
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
        if (speaker == "Gavin") { speakerAudio = GavBlip; }
        else if (speaker == "RA9") { speakerAudio = PerpBlip; }
        else { MakeSounds = false; }
        while (MakeSounds == true) {
            AS.PlayOneShot(speakerAudio);
            yield return new WaitForSeconds(2f);
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
        if (activeTyper != null)
        {
            StopCoroutine(activeTyper);
        }
        activeTyper = StartCoroutine(Typer(input));
        if (activeSpeaker != null)
        {
            StopCoroutine(activeSpeaker);
        }
        activeSpeaker = StartCoroutine(musicPlayer());

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

    public void updateAll(bool isLastDialouge = false)
    {
        Dialogue dialogue = gp.getCurrentDialogue();
        //textswitch
        gs.TextSwitch(dialogue.speaker);


        //audio
        speaker = dialogue.speaker;
        //sending the choice data to gamestate
        dialogueUpdate(dialogue.longText);
        //disable all buttons to clear screen
        option1Text.transform.parent.gameObject.SetActive(false);
        option2Text.transform.parent.gameObject.SetActive(false);
        option3Text.transform.parent.gameObject.SetActive(false);
        //shorttext
        if (!isLastDialouge) {// checking ahead for short text is unsafe when there is no next options
            for (int i = 0; i < dialogue.options.Count; ++i)
            {
                optionUpdate(gp.graph[dialogue.options[i]].shortText, i + 1);
            }
        }else{
            Destroy(option1Text.transform.parent.gameObject);
            Destroy(option2Text.transform.parent.gameObject);
            Destroy(option3Text.transform.parent.gameObject);
        }
        //stress
        gs.UpdateStress(dialogue.stressCost);
        //timer
        gs.SetMaxTimer(dialogue.maxTimer, dialogue.maxStressTimePenalty);
        //portraitTransitions
        if(dialogue.speaker == "Gavin")
        {
            gs.SetGavPortrait(dialogue.portraitTransitions);
        }
        else
        {
            gs.SetPerpPortrait(dialogue.portraitTransitions);
        }
    }
}

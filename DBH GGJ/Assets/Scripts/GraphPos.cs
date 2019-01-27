using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPos : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<int, Dialogue> graph;
    public int spawnDialogue;
    private int cursor;//stores an int because all dialogues are uniquely ID by an int
    private GameState gs;
    void Awake()
    {
        cursor = spawnDialogue;
        graph = new Dictionary<int, Dialogue>();
        List<Dictionary<string, object>> data = CSVReader.Read("test");
        Debug.Log("lines read in: " + data.Count);
        for(int i = 0; i < data.Count; ++i)
            graph[i + 2] = new Dialogue(i, data[i]);
    }

    void Start()
    {
        gs = GetComponent<GameState>();
    }

    public void SelectOption(int selectedButtonIndex)
    {
        //will check for a hardcoded interaction, if found it'll execute that and end the game
        if (checkHardCodedInteractions())
        {
            //load some other scene
            Debug.Log("End Game!");
            return;
        }

        if (graph[cursor].options.Count > selectedButtonIndex)
        {
            cursor = graph[cursor].options[selectedButtonIndex];
        }
        else
        {
            Debug.LogError("Invalid Dialogue option \"" + selectedButtonIndex + 
                "\" selected when no such option exists from \"" + cursor + "\".");
        }
    }

    //@Ulises: use this function below to get data out, all the members of Dialogue are public. Probably need to read 
    //options to make it so that when a player clicks a button, it calls the above SelectOption function with the 
    //correct int value based on index of the ordering in options so as to advance the game state
    public Dialogue getCurrentDialogue()
    {
        return graph[cursor];
    }

    private bool checkHardCodedInteractions()
    {
        //return true if the game should end
        switch (cursor)
        {
            //RA9 exit points
            case 29:
                if(gs.GetStress().perpStress >= 70)
                {
                    Debug.Log("game over");
                }
                else
                {
                    gs.PerpStresSet(80);
                }
                break;
            case 56:
                if (gs.GetStress().perpStress >= 80)
                {
                    Debug.Log("game over");
                }
                else
                {
                    gs.PerpStresSet(90);
                }
                //this one is also an audio break point
                break;
            case 63:
                if (gs.GetStress().perpStress >= 70)
                {
                    Debug.Log("game over");
                }
                else
                {
                    gs.PerpStresSet(80);
                }
                break;
            //Gav exit points
            case 36:
                if (gs.GetStress().gavStress >= 60)
                {
                    Debug.Log("game over");
                }
                else
                {
                    gs.PerpStresSet(90);
                }
                break;
            case 52:
                if (gs.GetStress().perpStress >= 90)
                {
                    Debug.Log("game over");
                }
                else
                {
                    gs.PerpStresSet(80);
                }
                break;
            default:
                break;
            //bad ending
            //good ending
            //audio shift points
            case 26:
                break;
            case 34:
                break;
            case 44:
                break;
        }
        return false;
    }
}

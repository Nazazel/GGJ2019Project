using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraphPos : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<int, Dialogue> graph;
    public int spawnDialogue;
    private BGM bgm;
    private int cursor;//stores an int because all dialogues are uniquely ID by an int
    private GameState gs;
    private UIUpdater uup;
    private gameOverTransition trans;
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
        uup = GetComponent<UIUpdater>();
        bgm = GameObject.Find("BGM").GetComponent<BGM>();
        trans = GameObject.Find("Transition").GetComponent<gameOverTransition>();
    }

    public void SelectOption(int selectedButtonIndex)
    {
        //will check for a hardcoded interaction, if found it'll execute that and end the game
        if (checkHardCodedInteractions())
        {
            uup.updateAll(true);
            Invoke("startFadeOut",7);
            Invoke("callEndGame", 14);
            Destroy(gs);
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
    private void startFadeOut()
    {
        trans.FadeOut();
    }
    private void callEndGame()
    {
        
        SceneManager.LoadScene("GameOver");
    }

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
                    return true;
                }
                else
                {
                    gs.PerpStresSet(80);
                }
                break;
            case 56:
                if (gs.GetStress().perpStress >= 80)
                {
                    return true;
                }
                else
                {
                    gs.PerpStresSet(90);
                }
                //this one is also an audio break point
                break;
            case 64:
                if (gs.GetStress().perpStress >= 90)
                {
                    return true;
                }
                else
                {
                    bgm.LowToHigh();
                }
                break;
            //Gav exit points
            case 36:
                if (gs.GetStress().gavStress >= 60)
                {
                    return true;
                }
                else
                {
                    gs.GavStressSet(90);
                }
                break;
            case 52:
                if (gs.GetStress().gavStress >= 90)
                {
                    return true;
                }
                else
                {
                    //
                }
                break;
            default:
                break;
            //bad ending
            case 45:
                return true;
            //good ending
            case 63:
                return true;
                //audio shift points
            case 32:
            case 39:
            case 40:
                bgm.PlayWilhelm();
                break;
            case 12:
            case 13:
                bgm.PlayWilhelm();
                bgm.LowToHigh();
                break;
            case 26:
            case 34:
            case 44:
                bgm.LowToHigh();
                break;
        }
        return false;
    }
}

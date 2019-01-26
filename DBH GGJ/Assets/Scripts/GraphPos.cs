using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPos : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<int, Dialogue> graph;
    public int spawnDialogue;
    private int cursor;//stores an int because all dialogues are uniquely ID by an int
    // Start is called before the first frame update
    void Start()
    {
        cursor = spawnDialogue;
        graph = new Dictionary<int, Dialogue>();
        List<Dictionary<string, object>> data = CSVReader.Read("small");
        for(int i = 0; i < data.Count; ++i)
            graph[i + 2] = new Dialogue(i, data[i]);
    }

    public void SelectOption(int selectedButtonIndex)
    {
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
}

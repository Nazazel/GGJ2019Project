﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Stress
{
    public float gavStress, perpStress;
    public Stress(float gavStrss, float perpStrss)
    {
        gavStress = gavStrss;
        perpStress = perpStrss;
    }
}

public struct Portrait
{
    public string type;
    public float time;
    public Portrait(string typ, float tim)
    {
        type = typ;
        time = tim;
    }
}

public class Dialogue
{
    public string
        shortText,//text that displays when this dialogue option is listed as a choice
        longText,//the resulting full text that results from clicking the shortText as a button
        speaker;//who is speaking "Gavin" for gav, anything else for the perp
    public int ID,
        defaultOption;//the unique identifier for this diaglogue object
    public float maxTimer, maxStressTimePenalty;//max time and max time lost due to stress, respectively
    public List<int> options;//IDs of other Dialogue entries that are options in response to this dialogue.
    public Stress stressCost;//represents stress change per char for this dialogue state
    public List<Portrait> portraitTransitions;//list of portrait types as well as times to set the character talking to, visually

    public Dialogue(int id, Dictionary<string, object> input)
    {
        shortText = (string)input["shortText"];
        longText = (string)input["longText"];
        speaker = (string)input["speaker"];
        ID = id + 2;//the spreadsheet is offset by 2 from the true value so w/e store it as its marked
        defaultOption = (int)input["default"];
        maxTimer = (float)input["maxTimer"];
        maxStressTimePenalty = (float)input["maxStressTimePenalty"];
        //building options list
        int n = 0;
        options = new List<int>();
        string s = (string)input["options"];
        foreach(string st in s.Replace("a", "").Split(','))
        {
            ++n;
            options.Add(int.Parse(st.Trim()));
        }
        //building stressCosts list using n from last list
        s = (string)input["stressCost"];
        string[] toGrabFrom = s.Replace("(", "").Replace(")", "").Replace(" ", "").Split(',');
        stressCost = new Stress(float.Parse(toGrabFrom[0]), float.Parse(toGrabFrom[1]));
        //building portrait list using n from last list
        s = (string)input["portraitTransitions"];
        portraitTransitions = new List<Portrait>();
        toGrabFrom = s.Replace("(", "").Replace(")", "").Replace(" ", "").Split(',');
        for (int i = 0; i < toGrabFrom.Length; i += 2)
        {
            portraitTransitions.Add(new Portrait(toGrabFrom[i], float.Parse(toGrabFrom[i + 1])));
        }
    }
}

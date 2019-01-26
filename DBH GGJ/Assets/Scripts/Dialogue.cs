using System.Collections;
using System.Collections.Generic;

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
    string ID,//Unique name for internal referencing
        shortText,//text that displays when this dialogue option is listed as a choice
        longText,//the resulting full text that results from clicking the shortText as a button
        speaker,//who is speaking "Gavin" for gav, anything else for the perp
        defaultOption;//... the default option from the list of options below
    List<string> options;//strings are IDs of other dialogue options to list as options for this dialogue encounter
    List<Stress> stressCosts;//associated with each entry in options, represents stress changes per char for that choice

    public Dialogue(string rawInput)
    {
        //parse code function call here
    }
}

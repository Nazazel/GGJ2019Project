using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameState : MonoBehaviour
{
     float GavinStress;// stress value of gavin
     float PerpStress;// stress value of perp
    public float timerTickRate;//the amount of time, in seconds that the timer increments at
    public float MaxTimer;     // dailouge choice timer
    public float CurrentTimer; // current time 
    public List<Portrait> GavinPortrait; //current portrait for gavin
    public List<Portrait> PerpPortrait; //current portrait for perp
    public Image GavinMeter;
    public Image PerpMeter;
    public Image timerImage;
    public textBoxTransition box;
    public GraphPos dialouge;
    public GraphPos sender;
    public UIUpdater UI;


    float GMaxStress = 60;
    float PMaxStress = 70;

    public Image GavImage;
    public Image PerpImage;


    //perp Images
    public Sprite PNeutral;
    public Sprite PAngry;
    public Sprite PImpressed;
    public Sprite PFurious;
    public Sprite PArrogant;
    public Sprite PProphetic;
    //

    //Gav iamges
    public Sprite GNeutral;
    public Sprite GAngry;
    public Sprite GSuprised;
    public Sprite GFearful;
    public Sprite GTense;
    public Sprite GPanic;
    public Sprite GArrogant;

    //


    // Start is called before the first frame update
    void Start()
    {
        GavinPortrait = new List<Portrait>();
        PerpPortrait = new List<Portrait>();
        UI = GetComponent<UIUpdater>();
        sender = GetComponent<GraphPos>();
        GavinStress = 0;
        PerpStress = 0;
        dialouge = GetComponent<GraphPos>();
        //MaxTimer = 0;
        CurrentTimer = 0;
      //  GavinPortrait = "Default";
      //  PerpPortrait = "Default";
        PerpMeter.fillAmount = 0;
        GavinMeter.fillAmount = 0;
        timerImage.fillAmount = 0;
        StartCoroutine(AdvanceTimer(timerTickRate));
        GMaxStress = 100;
        PMaxStress = 100;
    }

    public void GavStressSet(float i) { GMaxStress = i; }

    public void PerpStresSet(float i) { PMaxStress = i; }


    private IEnumerator AdvanceTimer(float tickRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(tickRate);
            TickTimer(tickRate);
        }
    }


    /// <summary>
    ///   add the associated stress values to each character from the passed stress struct 
    /// </summary>
    // <param name="StressVal"></param>
    public void UpdateStress(Stress StressVal) {
        GavinStress += StressVal.gavStress;
        PerpStress += StressVal.perpStress;
        if (StressVal.perpStress > 0)
            Debug.Log(PerpStress);
        //Debug.Log("GavStress: " + GavinStress + "\nRA9Stress: " + PerpStress);
    }
    /// <summary>
    /// return the current stress
    /// </summary>
    /// <returns></returns>
    public Stress GetStress() {
        Stress CurStress;
        CurStress.gavStress = GavinStress;
        CurStress.perpStress = PerpStress;
        return CurStress;
    }

 

    /// <summary>
    /// updates the timer the amount of time you have for dialouge choices 
    /// rounds MaxTimer to nearest 0.5
    /// </summary>
    // <param name="time"></param>
    public void SetMaxTimer(float max, float PotentialPenalty) {
        MaxTimer = (float)Math.Round( (max - ( (PerpStress/100)*PotentialPenalty)) *2 )/2;
        CurrentTimer = 0;
    }
    /// <summary>
    //// updates Gavin's portrait state with the new passed struct 
    /// </summary>
    //<param name="newPortrait"></param>
    public void SetGavPortrait(List<Portrait> newPortrait) {
        GavinPortrait = newPortrait;
        
    }

    /// <summary>
    /// returns gavins portrait string 
    /// </summary>
    public List<Portrait> GetGavPort() {
        return GavinPortrait;
    }   

    /// <summary>
    /// updates the perp's portrait state with the new passed struct 
    /// </summary>
    // <param name="newPortrait"></param>
    public void SetPerpPortrait(List<Portrait> newPortrait)
    {
        PerpPortrait= newPortrait;
     //   Debug.Log(GetPerpPort().ToString());
    }

    /// <summary>
    /// returns Perp portrait string 
    /// </summary>
    public List<Portrait> GetPerpPort()
    {
        return PerpPortrait;
    }

 

    /// <summary>
    /// stuff to do when timer ends
    /// </summary>
    private void TimerEnd() {
       
        for (int i = 0; i < dialouge.getCurrentDialogue().options.Count; i++) {
            if (dialouge.getCurrentDialogue().options[i] == dialouge.getCurrentDialogue().defaultOption) {
               
             //   Debug.Log("amount of options: " + dialouge.getCurrentDialogue().options.Count);
            //    Debug.Log("option i choose was: " + i);
                sender.SelectOption(i);
                CurrentTimer = 0;
                UI.updateAll();
                break;
            }
        }
        

    }

    /// <summary>
    /// ticks time for conversation
    /// </summary>
    /// 


    private void TickTimer(float seconds)
    {
        //increment currentTimer if wouldnt put past max time, else set to max time
        CurrentTimer = ((CurrentTimer + seconds) >= MaxTimer) ? MaxTimer : (CurrentTimer + seconds);
        //to make sure rounding errors dont compound and run away, round to nearest valid timeTickRate interval
        CurrentTimer = Mathf.Round(CurrentTimer * 1 / timerTickRate) * timerTickRate;
        
    }

    /// <summary>
    /// switches textbox based on speaker name passed 
    /// </summary>
    public void TextSwitch(string name) {

        if (name == "Gavin"){
            //Debug.Log("G");

            box.rightBox();
        }
        if (name =="RA9") {
           // Debug.Log("R");

            box.leftBox();
        }
    }

    /// <summary>
    /// put in update to continuosly update the fillamount of the images 
    /// </summary>
    public void UpdateImages() {
        PerpMeter.fillAmount = (float)Math.Min(PMaxStress,PerpStress);
        GavinMeter.fillAmount = (float)Math.Min(GMaxStress, GavinStress);

        timerImage.fillAmount = (float)Math.Min(MaxTimer, CurrentTimer / MaxTimer);
        if (CurrentTimer == MaxTimer)
        {
            // Debug.Log("timer end");
            TimerEnd();
        }


        if (GavinPortrait.Count > 0)
        {
            if (GavinPortrait[0].type == "Tense") { GavImage.sprite = GTense; }
            else if (GavinPortrait[0].type == "Neutral") { GavImage.sprite = GNeutral; }
            else if (GavinPortrait[0].type == "Surprised") { GavImage.sprite = GSuprised; }
            else if (GavinPortrait[0].type == "Fearful") { GavImage.sprite = GFearful; }
            else if (GavinPortrait[0].type == "Angry") { GavImage.sprite = GAngry; }
            else if (GavinPortrait[0].type == "Panic") { GavImage.sprite = GPanic; }
            else if (GavinPortrait[0].type == "Arrogant") { GavImage.sprite = GArrogant; }
            if (GavinPortrait.Count > 1)
            {
                if (CurrentTimer > GavinPortrait[1].time)
                {
                    if (GavinPortrait[1].type == "Tense") { GavImage.sprite = GTense; }
                    else if (GavinPortrait[1].type == "Neutral") { GavImage.sprite = GNeutral; }
                    else if (GavinPortrait[1].type == "Surprised") { GavImage.sprite = GSuprised; }
                    else if (GavinPortrait[1].type == "Fearful") { GavImage.sprite = GFearful; }
                    else if (GavinPortrait[1].type == "Angry") { GavImage.sprite = GAngry; }
                    else if (GavinPortrait[1].type == "Panic") { GavImage.sprite = GPanic; }
                    else if (GavinPortrait[1].type == "Arrogant") { GavImage.sprite = GArrogant; }
                }
            }
        }

        if (PerpPortrait.Count>0) { 
        if (PerpPortrait[0].type == "Impressed") { PerpImage.sprite = PImpressed; }
        else if (PerpPortrait[0].type == "Neutral") { PerpImage.sprite = PNeutral; }
        else if (PerpPortrait[0].type == "Furious") { PerpImage.sprite = PFurious; }
        else if (PerpPortrait[0].type == "Prophetic") { PerpImage.sprite = PProphetic; }
        else if (PerpPortrait[0].type == "Angry") { PerpImage.sprite = PAngry; }
        else if (PerpPortrait[0].type == "Arrogant") { PerpImage.sprite = PArrogant; }
        if (PerpPortrait.Count > 1)
        {
            if (CurrentTimer > PerpPortrait[1].time)
            {

                if (PerpPortrait[1].type == "Impressed") { PerpImage.sprite = PImpressed; }
                else if (PerpPortrait[1].type == "Neutral") { PerpImage.sprite = PNeutral; }
                else if (PerpPortrait[1].type == "Furious") { PerpImage.sprite = PFurious; }
                else if (PerpPortrait[1].type == "Prophetic") { PerpImage.sprite = PProphetic; }
                else if (PerpPortrait[1].type == "Angry") { PerpImage.sprite = PAngry; }
                else if (PerpPortrait[1].type == "Arrogant") { PerpImage.sprite = PArrogant; }

            }
        }
    }
        

    }

    /// <summary>
    /// handling of of the stress meters as a lose state
    /// Todo: fill in what happens if either stress gets to 100
    /// </summary>
    public void StressHandle() {
        if (GavinStress == 100 || PerpStress == 100) {
            //fill in
        }

    }


    // Update is called once per frame
    void Update()
    {
        UpdateImages();
        

    }
}

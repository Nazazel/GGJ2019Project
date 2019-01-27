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
    public Portrait[] GavinPortrait; //current portrait for gavin
    public Portrait[] PerpPortrait; //current portrait for perp
    public Image GavinMeter;
    public Image PerpMeter;
    public Image timerImage;
    public textBoxTransition box;


    // Start is called before the first frame update
    void Start()
    {
        GavinStress = 0;
        PerpStress = 0;
        //MaxTimer = 0;
        CurrentTimer = 0;
      //  GavinPortrait = "Default";
      //  PerpPortrait = "Default";
        PerpMeter.fillAmount = 0;
        GavinMeter.fillAmount = 0;
        timerImage.fillAmount = 0;
        StartCoroutine(AdvanceTimer(timerTickRate));
    }

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
        Debug.Log("GavStress: " + GavinStress + "\nRA9Stress: " + PerpStress);
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
    public void SetGavPortrait(Portrait[] newPortrait) {
        GavinPortrait = newPortrait;
    }

    /// <summary>
    /// returns gavins portrait string 
    /// </summary>
    public Portrait[] GetGavPort() {
        return GavinPortrait;
    }   

    /// <summary>
    /// updates the perp's portrait state with the new passed struct 
    /// </summary>
    // <param name="newPortrait"></param>
    public void SetPerpPortrait(Portrait[] newPortrait)
    {
        PerpPortrait= newPortrait;
    }

    /// <summary>
    /// returns Perp portrait string 
    /// </summary>
    public Portrait[] GetPerpPort()
    {
        return PerpPortrait;
    }

    /// <summary>
    /// stuff to do when timer ends
    /// </summary>
    private void TimerEnd() {
        //Debug.Log(CurrentTimer);
    }

    /// <summary>
    /// ticks time for conversation
    /// </summary>
    private void TickTimer(float seconds)
    {
        //increment currentTimer if wouldnt put past max time, else set to max time
        CurrentTimer = ((CurrentTimer + seconds) >= MaxTimer) ? MaxTimer : (CurrentTimer + seconds);
        //to make sure rounding errors dont compound and run away, round to nearest valid timeTickRate interval
        CurrentTimer = Mathf.Round(CurrentTimer * 1 / timerTickRate) * timerTickRate;
        TimerEnd();
    }

    /// <summary>
    /// switches textbox based on speaker name passed 
    /// </summary>
    public void TextSwitch(string name) {
        if (name == "Gavin"){ box.rightBox(); }
        if (name =="RA9") { box.leftBox(); }
    }

    /// <summary>
    /// put in update to continuosly update the fillamount of the images 
    /// </summary>
    public void UpdateImages() {
        PerpMeter.fillAmount = (float)Math.Min(100,PerpStress);
        GavinMeter.fillAmount = (float)Math.Min(100, GavinStress);
        timerImage.fillAmount = (float)Math.Min(MaxTimer, CurrentTimer / MaxTimer);

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

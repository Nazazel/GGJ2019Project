using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameState : MonoBehaviour
{
    public float GavinStress;// stress value of gavin
    public float PerpStress;// stress value of perp
    public float MaxTimer;     // dailouge choice timer
    public float CurrentTimer; // current time 
    public string GavinPortrait; //current portrait for gavin
    public string PerpPortrait; //current portrait for perp
    public Image GavinMeter;
    public Image PerpMeter;



    // Start is called before the first frame update
    void Start()
    {
        GavinStress = 0;
        PerpStress = 0;
        MaxTimer = 0;
        CurrentTimer = 0;
        GavinPortrait = "Default";
        PerpPortrait = "Default";
        PerpMeter.fillAmount = 0;
        GavinMeter.fillAmount = 0;
        
    }

    
    /// <summary>
    ///   add the associated stress values to each character from the passed stress struct 
    /// </summary>
    // <param name="StressVal"></param>
    public void UpdateStress(Stress StressVal) {
        GavinStress += StressVal.gavStress;
        PerpStress += StressVal.perpStress;
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
        MaxTimer = (float)Math.Round((max - ((PerpStress / 100) * PotentialPenalty)) * 2) / 2;
        CurrentTimer = 0;
    }
    /// <summary>
    //// updates Gavin's portrait state with the new passed struct 
    /// </summary>
    //<param name="newPortrait"></param>
    public void SetGavPortrait(Portrait newPortrait) {
        GavinPortrait = newPortrait.type;
    }

    /// <summary>
    /// returns gavins portrait string 
    /// </summary>
    public string GetGavPort() {
        return GavinPortrait;
    }   

    /// <summary>
    /// updates the perp's portrait state with the new passed struct 
    /// </summary>
    // <param name="newPortrait"></param>
    public void SetPerpPortrait(Portrait newPortrait)
    {
        PerpPortrait = newPortrait.type;
    }

    /// <summary>
    /// returns Perp portrait string 
    /// </summary>
    public string GetPerpPort()
    {
        return PerpPortrait;
    }

    /// <summary>
    /// stuff to do when timer ends
    /// </summary>
    public void TimerEnd() {
        // fill stuff to do when timer ends
        Debug.Log("tick");
    }

    /// <summary>
    /// timer, increments CurrentTimer till reaches MaxTimer Value
    /// Increment the currentTimer 
    /// </summary>
    public void TickTimer(float period) {
        float PostTime = Time.time + period;
        //while there is still time in the main timer
        while (CurrentTimer <= MaxTimer) {
            //check if its been period length of time since called this fxn
            if (Time.time > PostTime) {
                //add that time period to the current timer nad postTimer, to setup for next tick
                CurrentTimer += period;
                PostTime += period;
            }
        }
        TimerEnd();
    }

    public void UpdateMeter() {
        PerpMeter.fillAmount = Math.Min(100, PerpStress);
        GavinMeter.fillAmount = Math.Min(100, GavinStress);
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
        
    }
}

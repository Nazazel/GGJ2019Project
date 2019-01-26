using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float GavinStress;// stress value of gavin
    public float PerpStress;// stress value of perp
    public float MaxTimer;     // dailouge choice timer
    public float CurrentTimer; // current time 
    public string GavinPortrait; //current portrait for gavin
    public string PerpPortrait; //current portrait for perp



    // Start is called before the first frame update
    void Start()
    {
        GavinStress = 0;
        PerpStress = 0;
        MaxTimer = 0;
        CurrentTimer = 0;
        GavinPortrait = "Default";
        PerpPortrait = "Default";
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
    /// </summary>
    // <param name="time"></param>
    public void SetMaxTimer(float time) {
        MaxTimer = time;
        CurrentTimer = 0;
    }
    /// <summary>
    //// updates Gavin's portrait state with the new passed struct 
    /// </summary>
    //<param name="newPortrait"></param>
    public void SetGavPortrait(Portrait newPortrait) {
        GavinPortrait = newPortrait.type;
    }

    public string GetGavPort() {
        return GavinPortrait;
    }   

    /// <summary>
    /// updates the perp's portrait state with the new passed struct 
    /// </summary>
    // <param name="newPortrait"></param>
    public void SetPerpPortrait(Portrait newPortrait)
    {
        PerpPortrait= newPortrait.type;
    }

    public string GetPerpPort()
    {
        return PerpPortrait;
    }

    /// <summary>
    /// stuff to do when timer ends
    /// </summary>
    public void TimerEnd() {
        // fill stuff to do when timer ends
    }

    /// <summary>
    /// timer, increments CurrentTimer till reaches MaxTimer Value
    /// </summary>
    public void StartTimer() {
        while (CurrentTimer != MaxTimer) {
            CurrentTimer += Time.deltaTime;
        }
        TimerEnd();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

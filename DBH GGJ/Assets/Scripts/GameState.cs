using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    float GavinStress;// stress value of gavin
    float PerpStress;// stress value of perp
    float MaxTimer;     // dailouge choice timer
    float CurrentTimer; // current time 
    string GavinPortrait; //current portrait for gavin
    string PerpPortrait; //current portrait for perp



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
    void UpdateStress(Stress StressVal) {
        GavinStress += StressVal.gavStress;
        PerpStress += StressVal.perpStress;
    }

    /// <summary>
    /// updates the timer the amount of time you have for dialouge choices 
    /// </summary>
    // <param name="time"></param>
    void SetMaxTimer(float time) {
        MaxTimer = time;
        CurrentTimer = 0;
    }
    /// <summary>
    //// updates Gavin's portrait state with the new passed struct 
    /// </summary>
    //<param name="newPortrait"></param>
    void SetGavPortrait(Portrait newPortrait) {
        GavinPortrait = newPortrait.type;
    }




    /// <summary>
    /// updates the perp's portrait state with the new passed struct 
    /// </summary>
    // <param name="newPortrait"></param>
    void SetPerpPortrait(Portrait newPortrait)
    {
        PerpPortrait= newPortrait.type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

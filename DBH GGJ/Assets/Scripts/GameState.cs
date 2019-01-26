using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    float GavinStress;// stress value of gavin
    float PerpStress;// stress value of perp
    float Timer;     // dailouge choice timer
   
    string GavinPortrait; //current portrait for gavin
    string PortraitPerp; //current portrait for perp



    // Start is called before the first frame update
    void Start()
    {
        GavinStress = 0;
        PerpStress = 0;
        Timer = 0;
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
    void UpdateTimer(float time) {
        Timer = time;
    }
    /// <summary>
    //// updates Gavin's portrait state with the new passed struct 
    /// </summary>
    //<param name="newPortrait"></param>
    void UpdateGavPortrait(Portrait newPortrait) {
        GavinPortrait = newPortrait.type;
    }




    /// <summary>
    /// updates the perp's portrait state with the new passed struct 
    /// </summary>
    // <param name="newPortrait"></param>
    void UpdatePerpPortrait(Portrait newPortrait)
    {
        GavinPortrait = newPortrait.type;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

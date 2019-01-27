using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{  
  

    public void newGame()
    {
        //SceneManager.LoadScene("MainLevel");
    }

    public void credits()
    {
        //SceneManager.LoadScene("Credits");
    }

    public void retry()
    {
        //SceneManager.LoadScene("MainLevel");
    }

    public void mainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        Application.Quit();
    }
}

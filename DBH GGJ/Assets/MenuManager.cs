using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public gameOverTransition tr;
    public BGM music;

    public void newGame()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            StartCoroutine(sendTransition("NG1"));
        }
        else
        {
            StartCoroutine(sendTransition("NG2"));
        }
    }

    public void credits()
    {

        StartCoroutine(sendTransition("CR"));
    }

    public void retry()
    {
        StartCoroutine(sendTransition("RT"));
    }

    public void mainMenu()
    {
        StartCoroutine(sendTransition("MM"));
    }

    public void quit()
    {
        Application.Quit();
    }

    public IEnumerator sendTransition(string sc)
    {
        if(sc == "NG1")
        {
            tr.FadeOut();
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("Intro");
        }
        else if (sc == "NG2")
        {
            tr.FadeOut();
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("Intro");

        }
        else if (sc == "CR")
        {
            tr.FadeOut();
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("Credits");
        }
        else if (sc == "RT")
        {
            tr.FadeOut();
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("MainLevel");
        }
        else if (sc == "RT")
        {
            tr.FadeOut();
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("MainLevel");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverTransition : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;
    public AudioSource music;

    public TextAsset textFile;
    public string[] textLines;


    public int currentLine;
    public int endAtLine;

    public bool started;

    public float fadeSpeed = 10.0f;
    public Image FadeImg;

    // Use this for initialization
    void Start()
    {
        //Cursor.visible = false;
        //music = gameObject.GetComponent<AudioSource>();
        started = false;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }


        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        //FadeImg = GameObject.Find("Fade").GetComponent<Image>();
        InvokeRepeating("FadeToClear", 0.0f, 0.1f);

    }

    public void FadeToClear()
    {
        //Bug: this gets called again whenever Level One is entered
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (FadeImg.color.a < 0.05f)
        {
            CancelInvoke("FadeToClear");
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;
        }
    }

    public void FadeToBlack()
    {
        FadeImg.enabled = true;
        FadeImg.color = Color.Lerp(FadeImg.color, Color.black, fadeSpeed * Time.deltaTime);
        if (FadeImg.color.a == 1.0f)
        {
            CancelInvoke("FadeToBlack");
        }
    }

    public void FadeOut()
    {
        InvokeRepeating("FadeToBlack", 0.0f, 0.1f);
    }


}

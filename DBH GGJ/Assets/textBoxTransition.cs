using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBoxTransition : MonoBehaviour
{
    public Image textBox;
    public bool shifting;
    public bool started;
    public float shiftDir;
    public GameObject leftB;
    public GameObject rightB;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        textBox = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            //find out what direction to move it in; if the box is already in the right place, it auto-cancels the move
            if (shiftDir < 0)
            {
                speed = 800.0f * Time.deltaTime;
                if (transform.position != leftB.transform.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, leftB.transform.position, speed);
                }
                else
                {
                    shifting = false;
                }
            }
            else
            {
                speed = 800.0f * Time.deltaTime;
                if (transform.position != rightB.transform.position)
                { 
                    transform.position = Vector3.MoveTowards(transform.position, rightB.transform.position, speed);
                }
                else
                {
                    shifting = false;
                }
            }
        }
    }

    //call this method to begin moving text box left
    //this sets up the text box so that rA9 is speaking
    public void leftBox()
    {
        shiftDir = -1;
        StartCoroutine("shiftLeft");
    }

    //call this method to begin moving text box right
    //this sets up the text box so that Gavin is speaking
    public void rightBox()
    {
        shiftDir = 1;
        StartCoroutine("shiftRight");
    }

    public IEnumerator shiftLeft()
    {
        shifting = true;
        started = true;
        yield return new WaitUntil(() => shifting == false);
        started = false;
    }

    public IEnumerator shiftRight()
    {
        shifting = true;
        started = true;
        yield return new WaitUntil(() => shifting == false);
        started = false;
    }
}

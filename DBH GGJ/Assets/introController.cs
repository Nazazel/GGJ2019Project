using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introController : MonoBehaviour
{ 
    public Text inText;
    public bool started;
    public gameOverTransition transition;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            started = true;
            StartCoroutine("IntroText");
        }
    }

    public IEnumerator IntroText()
    {
        inText.text = "The year is 2036";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "The current unemployment rate of 28% is expected to increase yet again as a new line of androids enters the market";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "Though humans have grown to despise androids for being more efficient, resilient and intelligent, they've become dependent on the machines, purchasing them for the household, businesses and the like";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "These machines sternly adhere to their protocol which advocates human superiority. They are to do whatever humans say, take whatever beating humans deal, and most importantly, treat humans with the utmost respect. They feel nothing, think nothing and are often seen as less than nothing";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "It was a cold, snowy evening in Detroit, Michigan. Lights slowly diminished within the city as families finished dinners and businesses locked up for the night";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "Silence echoed throughout the police department with only the occasional clink of Gavin's lighter adding variety to the otherwise depressing atmosphere";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "The junior detective waited, staring at the clock for what seemed like an eternity. Then, with a barely audible beep, it was 3:31 AM";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "The brunet shook his head and fought the urge to yawn. He glanced over at his cold coffee then sighed";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "\"Out of all the fuckin' people, they gave me the damn graveyard shift\"";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "He grumbled to himself before taking out a cigarette and placing it between his lips. He lit the cig and let it sit for a while as he sunk into his chair with a bored groan. Smoke blew out of his nose as he huffed shortly after";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "Gavin's lids grew heavy, the rhythmic creaking of his chair rocking him to sleep. All was peaceful, until the sound of hurried footsteps snapped the detective back to reality";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "Suddenly, a disheveled operator burst through the heavy doors that connected central station to the dispatch center. The woman looked horrified";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "\"I - I don't know what to do,\" she was trembling, \"He s-said he'd only talk to a cop.\"";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "The detective stood from his seat, \"Who said he'd only talk to a cop?\"";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "She shook her head as sweat beaded near her hairline, \"I think he's killed someone.\"";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "Gavin's eyes rounded, his heart rate skyrocketing in the process";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        inText.text = "\"He's waiting on the phone,\" the operator lowered her head. \"He's only going to talk to an officer,\" she reiterated";
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        yield return new WaitForSeconds(0.1f);
        transition.FadeOut();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("MainLevel");
    }
}

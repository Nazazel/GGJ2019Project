using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionSender : MonoBehaviour
{
    public Dialogue diagDatabase;
    public GraphPos decTree;

    // Start is called before the first frame update
    void Start()
    {
        decTree = GetComponent<GraphPos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendChosen(int choice)
    {
        decTree.SelectOption(choice);
    }
}

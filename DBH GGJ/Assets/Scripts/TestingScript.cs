﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("test");
        for (int i = 0; i < data.Count; ++i)
        {
            Debug.Log("Speaker" + data[i]["Speaker"]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float time;
    public Text timeText;
	// Use this for initialization
	void Start () {
        time = 0;
        timeText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        Debug.Log(time);
        timeText.text = Mathf.Round(time).ToString();
    }
}

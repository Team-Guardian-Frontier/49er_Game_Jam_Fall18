using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float time;
    public Text timeText;
	// Use this for initialization
	void Start () {
        time = 0;
        if (timeText == null)
        {
            timeText = GameObject.Find("Timer").GetComponent<Text>();
        }
        
        timeText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeText.text = Mathf.Round(time).ToString();
    }
}

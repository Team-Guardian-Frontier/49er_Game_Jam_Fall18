using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {
    public Text speedTxt;
    private Rigidbody2D playerSpeed;
    public float x;
	// Use this for initialization
	void Start () {

        speedTxt.text = " Mph";
        playerSpeed = GameObject.Find("Player").GetComponent<Rigidbody2D>();

	}


    // Update is called once per frame
    void Update () {

        speedTxt.text = Mathf.Round(playerSpeed.velocity.x) + "Mph";
        x = playerSpeed.velocity.x;


    }
    
}

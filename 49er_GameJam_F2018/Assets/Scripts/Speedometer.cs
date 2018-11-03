using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {
    public float speed;
    public Text speedTxt;
    private Rigidbody2D playerSpeed;
	// Use this for initialization
	void Start () {

        speed = 0;
        speedTxt.text = " Mph";
        playerSpeed = GameObject.Find("Player").GetComponent<Rigidbody2D>();

	}
	
    /*

	// Update is called once per frame
	void Update () {

        speedTxt.text = playerSpeed.velocity.x + "Mph";

	}
    */
}

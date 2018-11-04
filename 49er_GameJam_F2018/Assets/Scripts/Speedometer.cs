using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {

    public PlayerController controller;
    public Text speedTxt;
    private Rigidbody2D playerSpeed;
    public float x;
    public float xPos = 0;
    public float yPos = -55;

	// Use this for initialization
	void Start () {

        speedTxt.text = " Mph";
        playerSpeed = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        speedTxt.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos, Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos, Camera.main.WorldToScreenPoint(controller.transform.position).z);

    }


    // Update is called once per frame
    void Update () {

        //speedTxt.text = Mathf.Round(playerSpeed.velocity.x) + "Mph";
        //x = playerSpeed.velocity.x;


    }

    private void LateUpdate()
    {
        speedTxt.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos, Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos, Camera.main.WorldToScreenPoint(controller.transform.position).z);

        speedTxt.text = Mathf.Round(playerSpeed.velocity.x) + "Mph";
        x = playerSpeed.velocity.x;
    }

}

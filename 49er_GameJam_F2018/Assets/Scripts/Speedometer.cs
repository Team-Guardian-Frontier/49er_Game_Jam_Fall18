using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {

    public PlayerController controller;
    public Text speedTxt;
    private GameObject player;
    private Rigidbody2D playerSpeed;
    public float x;
    public float xPos = 0;
    public float yPos = -55;

    // USE AWAKE. The text elements will be null exceptions if you use start.
    void Awake () {




        //automatically find objects
        if (player == null)
            player = GameObject.Find("Player");
        if (playerSpeed == null)
            playerSpeed = player.GetComponent<Rigidbody2D>();
        if (controller == null)
            controller = player.GetComponent<PlayerController>();
        if (speedTxt == null)
            speedTxt = GameObject.Find("Speedometer").GetComponent<Text>();
       
            //Add code here to break something if these are null.


        speedTxt.text = " Mph";

        speedTxt.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos, 
                                                    Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos, 
                                                    Camera.main.WorldToScreenPoint(controller.transform.position).z);


    }


    // Update is called once per frame
    void Update () {

        //speedTxt.text = Mathf.Round(playerSpeed.velocity.x) + " Mph";
        //x = playerSpeed.velocity.x;


    }

    private void LateUpdate()
    {

        if (speedTxt != null)
        {
            speedTxt.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos,
                                                        Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos,
                                                        Camera.main.WorldToScreenPoint(controller.transform.position).z);
            speedTxt.text = Mathf.Round(playerSpeed.velocity.x) + " MPH";
        }
        
        x = playerSpeed.velocity.x;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time;
    public Text timeText;
    private GameObject player;
    public PlayerController controller;
    private ToggleUI toggy;
    public float xPos = 0;
    public float yPos = 55;

    private Vector3 pos;
    private float posY;

    // USE AWAKE. The text elements will be null exceptions if you use start.
    void Start () {
        time = 0;

        ObjFinder();
       
        
        timeText.text = "";

        timeText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos, Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos, Camera.main.WorldToScreenPoint(controller.transform.position).z);
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if (timeText != null)
            timeText.text = Mathf.Round(time).ToString();
        else
            ObjFinder();

        // timeText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x, Camera.main.WorldToScreenPoint(controller.transform.position).y, Camera.main.WorldToScreenPoint(controller.transform.position).z);

    }

    private void LateUpdate()
    {
        if (timeText != null)
            timeText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos,
                                                    Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos,
                                                    Camera.main.WorldToScreenPoint(controller.transform.position).z);
        else
            ObjFinder();

    }

    void ObjFinder()
    {
        if (player == null)
            player = GameObject.Find("Player");
        if (controller == null)
            controller = player.GetComponent<PlayerController>();

        if (timeText == null)
        {
            toggy = this.GetComponent<ToggleUI>();
            timeText = toggy.getTextObject("time").GetComponent<Text>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time;
    public Text timeText;
    public PlayerController controller;
    public float xPos = 0;
    public float yPos = 55;

    private Vector3 pos;
    private float posY;

    // Use this for initialization
    void Start () {
        time = 0;
        timeText.text = "";

        timeText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos, Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos, Camera.main.WorldToScreenPoint(controller.transform.position).z);
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        timeText.text = Mathf.Round(time).ToString();

       // timeText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x, Camera.main.WorldToScreenPoint(controller.transform.position).y, Camera.main.WorldToScreenPoint(controller.transform.position).z);

    }

    private void LateUpdate()
    {
        timeText.transform.position = new Vector3(Camera.main.WorldToScreenPoint(controller.transform.position).x + xPos, Camera.main.WorldToScreenPoint(controller.transform.position).y + yPos, Camera.main.WorldToScreenPoint(controller.transform.position).z);

    }
}

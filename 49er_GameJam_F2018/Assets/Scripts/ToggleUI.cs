using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {
    public GameObject speed;
    public GameObject timer;
    public int timeUp;

    public int pauseDelay = 85;

    private int speedC = 0;
    private int timerC = 0;
    private int pauseC = 1000;

    // Use this for initialization

    void Awake () {

        ObjFinder();

        timer.SetActive(false);
        speed.SetActive(false);

        Time.timeScale = 1;
	}

    private void FixedUpdate()
    {
        ObjFinder();
    }

    // Update is called once per frame
    void Update () {

        

        //Pause Function
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }

            else //if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }

        //if (pauseC == pauseDelay) Time.timeScale = 1;

        if (Input.GetKey(KeyCode.O))
        {
            timer.SetActive(true);
            timerC = 0;
        }



        if (Input.GetKey(KeyCode.P))
        {

            speed.SetActive(true);
            speedC = 0;

        }


        if (speedC > timeUp && !Input.GetKey(KeyCode.P)) 
        {
            speed.SetActive(false);
        }

        if (timerC > timeUp && !Input.GetKey(KeyCode.O)) 
        {
            timer.SetActive(false);

        } 

        pauseC++;
        timerC++;
        speedC++;
    }

    void StartTime() {
        Time.timeScale = 1;
    }

    void ObjFinder()
    {

        //find by name
        if (speed == null)
            speed = GameObject.Find("Speedometer");
        if (timer == null)
            timer = GameObject.Find("Timer");
    }

    public GameObject getTextObject(string which)
    {
        GameObject finnaTurn;
        if (timer != null && speed != null)
        {
            if (which.Equals("speed"))
            {
                speed.SetActive(true);
                finnaTurn = speed;
                speed.SetActive(false);
            }
            else if (which.Equals("time"))
            {
                timer.SetActive(true);
                finnaTurn = timer;
                timer.SetActive(false);
            }
            else
            {
                Debug.Log("Incorrect String while getting timer/speed");
                finnaTurn = null;
            }
        }
        else
        {
            finnaTurn = null;
        }
        return finnaTurn;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour {
    public GameObject speed;
    public GameObject timer;
    public int timeUp;

    private int speedC = 0;
    private int timerC = 0;

    // Use this for initialization
    void Start () {

        timer.SetActive(false);
        speed.SetActive(false);

        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }

            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            timer.SetActive(true);
            timerC = 0;
        }



        if (Input.GetKeyDown(KeyCode.P))
        {

            speed.SetActive(true);
            speedC = 0;

        }


        if (speedC > timeUp && !Input.GetKeyDown(KeyCode.P)) 
        {
            speed.SetActive(false);
        }

        if (timerC > timeUp && !Input.GetKeyDown(KeyCode.O)) 
        {
            timer.SetActive(false);

        }

        timerC++;
        speedC++;
    }
}

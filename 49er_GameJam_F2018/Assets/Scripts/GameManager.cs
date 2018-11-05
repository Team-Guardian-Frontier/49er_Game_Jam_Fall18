using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
Author: Dillon Zhong
Last Change: Dillon - created script
Script summary
    - Game Manager Script. Anything that controls the game as a whole should be stored here: Restart, Game over
list of fields:
    - GameManger: current instance of GM
    - Player
    - Controller: Player's PlayerController.
Notes:
    Quick reset is on this script
*/

public class GameManager : MonoBehaviour {

    //this object is the gameManager. All room state scripts are attatched here.
    private static GameManager instance = null;
    private GameObject Player;
    private PlayerController controller;
    public Text GMText;
    private float lastTime;
    private Timer timer;

    private bool timeset;


    void Awake()
    {

        //Prevent Duplicates
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        if (GMText == null)
        {
            GMText = GameObject.Find("GameOver").GetComponent<Text>();
        }
        GMText.text = "";


        timer = this.GetComponent<Timer>();
        //DontDestroyOnLoad(gameObject);
        /* Can't do above, because we need the awake and start functions on scripts on this object.
        If we had it, this would never reload, and they would point to the same references throughout entire game
        We need to separate between game manager and something like a scene manager to attatch things that reset in a scene.
        */

        timeset = false;

    }


    // Update is called once per frame
    void Update() {

        if (GMText == null)
        {
            GMText = GameObject.Find("GameOver").GetComponent<Text>();
        }




        //Find player, get controller.
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<PlayerController>();

            //restart if player deleted.
            if (Player == null)
            {
                GameOver(-1);
            }
        }
        else //all player functions if the player isn't null.
        {
            
            
        }

        //Quick restart for Debug, R
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOver(-1);
        }

    }

    public void GameOver(int goo)
    {
        //goo < 0 game over, anything else is win.

        if (!timeset)
        {
            lastTime = timer.time;
            timeset = true;
        }

        if (GMText == null)
        {
            GMText = GameObject.Find("GameOver").GetComponent<Text>();
        }
        
        if (GMText != null)
        {
            if (goo <= 0)
            {
                GMText.text = "Game Over!";
                Invoke("Restart", 3);
            }
            else 
            {
                //placeholder.
                GMText.text = "You win! Your Time is " + lastTime;
                //HS?
                Invoke("Restart", 5);
            }
        }

        
        

    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    void Awake()
    {
        //Prevent Duplicates
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


    }


    // Update is called once per frame
    void Update() {

        //Find player, get controller.
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            controller = Player.GetComponent<PlayerController>();
            Debug.Log("I am bog" + controller.decelDam);

            //restart if player deleted.
            if (Player == null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else //all player functions if the player isn't null.
        {
            //restart if player slowed to halt
            if (controller.moveSpeed <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
            
        }

        //Quick restart for Debug, R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}

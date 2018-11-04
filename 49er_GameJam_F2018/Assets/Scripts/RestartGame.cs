using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
Author: Dillon Zhong
Last Change: Dillon - created script
Script summary
    - A standard script that lets objects damage players that enter the collider.
list of fields:

Notes:
    If you try to connect a prefab to a public object, anything it runs will run off the prefab.
    Make sure the object has a trigger collider attatched.
*/

public class RestartGame : MonoBehaviour {

    private PlayerController controller;

    //Trigger collision detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<Timer>().time = 0;
            controller = other.gameObject.GetComponent<PlayerController>();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

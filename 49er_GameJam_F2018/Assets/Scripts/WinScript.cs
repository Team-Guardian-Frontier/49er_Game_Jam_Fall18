using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {



    private PlayerController controller;

    //Trigger collision detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        //checks if what entered trigger
        if (other.gameObject.CompareTag("Player"))
        {
            controller = other.gameObject.GetComponent<PlayerController>();
            controller.WinnerDinner();
        }
    }
}

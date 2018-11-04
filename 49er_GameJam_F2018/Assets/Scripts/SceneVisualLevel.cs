using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Dillon Zhong
Last Change: DZ - created Script
Script summary: Easy access script that controls what the visual level is.
list of fields:
    - thePlayer: gets the playercontroller script
    - lastPlayerPosition: Stores the player's position
    - distanceToMove: 
(Any extra notes):
*/

public class SceneVisualLevel : MonoBehaviour {

    public enum VLevel { Urban, Dream, Surreal };

    [SerializeField]
    private VLevel GlobalVisLevel;

    private GameObject player;
    private PlayerController controller;
    private float percentage;

	// Use this for initialization
	void Start () {
        GlobalVisLevel = VLevel.Urban;
        ObjLoader();
	}
	
	// Update is called once per frame
	void Update () {
        //Update the visual level here.
        if (controller != null)
        {
            //currently setting visual level in equal intervals of max speed.
            percentage = controller.moveSpeed / controller.maxSpeed;
            if (percentage > .66f)
            {
                GlobalVisLevel = VLevel.Surreal;
            }
            else if (percentage < .33f)
            {
                GlobalVisLevel = VLevel.Urban;
            }
            else
            {
                GlobalVisLevel = VLevel.Dream;
            }
 
        }
		
	}

    public VLevel getVisualLevel()
    {
        return GlobalVisLevel;
    }

    void ObjLoader()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            if (controller == null)
                controller = player.GetComponent<PlayerController>();
        }
    }
}


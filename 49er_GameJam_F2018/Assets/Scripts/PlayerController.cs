using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Irvin Naylor
Last Change: Implemented auto movement and jumping
Script summary
    - Script starts by using Player's Rigidbody component to continuously move forward
    - If the jump key is held down, the player jumps.
list of fields
    - moveSpeed: movement speed forward
    - jumpForce: Upward jump force (how high can they jump?)
(Any extra notes)
*/


public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D RigidBody_A;

	// Use this for initialization
	void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        RigidBody_A.velocity = new Vector2(moveSpeed, RigidBody_A.velocity.y);

        //is the character jumping?

        if (Input.GetKeyDown(KeyCode.W) )
        {
            RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
        }
	}
}

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
    - grounded: is the player on the ground?
    - whatIsGround: determines the layer the ground is on

    - myCollider: gets the Collider2d component from the player
(Any extra notes)
*/


public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D RigidBody_A;
    private Collider2D myCollider;

    public bool grounded;
    public LayerMask whatIsGround;


	void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //returns true or false: is the player's collider touching another collider on the specified layer (aka the ground)?

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        RigidBody_A.velocity = new Vector2(moveSpeed, RigidBody_A.velocity.y);

        //is the character jumping?

        if (Input.GetKeyDown(KeyCode.W) )
        {

            if (grounded) // is grounded true?
            {
                RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
            }
        }
	}
}

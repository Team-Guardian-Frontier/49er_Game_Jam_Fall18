﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Irvin Naylor
Last Change: Michael - Adding Ducking
Script summary
    - Script starts by using Player's Rigidbody component to continuously move forward
    - If the jump key is held down, the player jumps.
list of fields
    - moveSpeed: movement speed forward
    - jumpForce: Upward jump force (how high can they jump?)
    - maxSpeed: Speed Cap for player
    - accel: a proportionate value for how quickly the player accelerates
    - decelDam: the speed reduced when player gets hit
    -iTime: time the player is invincible

    - grounded: is the player on the ground?
    - whatIsGround: determines the layer the ground is on

    - myCollider: gets the Collider2d component from the player
Notes:
*/


public class PlayerController : MonoBehaviour {

    //TEST VALUE
    public bool inited = false;

    public float moveSpeed;
    public float jumpForce;

    public float maxSpeed;
    public float accel;
    public float decelDam;


    public float iTime;

    private bool invincible;

    public Sprite Stand;
    public Sprite Duck;

    private Rigidbody2D RigidBody_A;
    private Collider2D myCollider;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    public bool grounded;
    public LayerMask whatIsGround;

    private float totalDamage;
    
    public float jumpTime;
    public float jumpTimeCounter;
    public bool stoppedJumping;



    void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        //adjusts acceleration so it's a reasonable value to input.
        accel = accel/100;

        inited = true;

        invincible = false;

        jumpTimeCounter = jumpTime;
	}

    // Update is called once per frame
    void Update()
    {

        //returns true or false: is the player's collider touching another collider on the specified layer (aka the ground)?

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        RigidBody_A.velocity = new Vector2(moveSpeed, RigidBody_A.velocity.y);

        //reset jump time on the ground
        if (grounded) // is grounded true?
        {
            jumpTimeCounter = jumpTime;
        }

        //is the character jumping?

        if (Input.GetKeyDown(KeyCode.W))
        {

            if (grounded) // is grounded true?
            {
                RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        if (Input.GetKey(KeyCode.W) && !stoppedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }


        if (Input.GetKeyDown(KeyCode.S) && grounded) 
        {
            spriteRenderer.sprite = Duck;
            boxCollider.size = new Vector2(1, (float).5);
            boxCollider.offset = new Vector2(0, (float)-.25);

        } 
        else if (Input.GetKeyUp(KeyCode.S))
        {
            spriteRenderer.sprite = Stand;
            boxCollider.size = new Vector2(1, 1);
            boxCollider.offset = new Vector2(0, 0);

        }

        //Accelerate velocity
        if (moveSpeed < maxSpeed)
        {
            if (Time.timeScale == 0)
            {
                moveSpeed = moveSpeed;
            }
            else
            {
                moveSpeed += accel;
            }
        }
        else
        {
            moveSpeed = maxSpeed;
        }
}

    //Damage called from other objects
    public void SlowDown()
    {
        Debug.Log("I am " + invincible);

        if (!invincible)
        {
            totalDamage = decelDam * (moveSpeed / maxSpeed);
            moveSpeed -= totalDamage;
            invincible = true;
            Invoke("ResetInvulnerability", iTime);

            Debug.Log("dam" + totalDamage);

        }

    }

    void ResetInvulnerability()
    {
        invincible = false;
    }
}

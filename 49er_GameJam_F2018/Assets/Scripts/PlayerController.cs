using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Irvin Naylor
Last Change: Dillon - Deceleration damage setup.
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

    private Rigidbody2D RigidBody_A;
    private Collider2D myCollider;

    public bool grounded;
    public LayerMask whatIsGround;

    private float totalDamage;



	void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        //adjusts acceleration so it's a reasonable value to input.
        accel = accel/100;

        inited = true;

        invincible = false;
        
        
	}

    // Update is called once per frame
    void Update()
    {

        //returns true or false: is the player's collider touching another collider on the specified layer (aka the ground)?

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        RigidBody_A.velocity = new Vector2(moveSpeed, RigidBody_A.velocity.y);

        //is the character jumping?

        if (Input.GetKeyDown(KeyCode.W))
        {

            if (grounded) // is grounded true?
            {
                RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
            }
        }

        //Accelerate velocity
        if (moveSpeed < maxSpeed)
        {
            moveSpeed += accel;
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

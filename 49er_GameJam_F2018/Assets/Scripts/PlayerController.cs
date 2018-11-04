using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Irvin Naylor
Last Change: Michael - Added Flashing
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

    public Color flash;
    private Color mainColor = new Color(255,255,255);

    public float moveSpeed;
    public float jumpForce;

    public float maxSpeed;
    public float minSpeed;
    public float accel;
    public float decelDam;


    public float iTime = 3;

    private bool invincible;
    private bool Dyin;

    public Sprite Stand;
    public Sprite Duck;

    private Rigidbody2D RigidBody_A;
    private Collider2D myCollider;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    public bool grounded;
    public LayerMask whatIsGround;

    private float totalDamage;

    private int flashC;
    public int flashAmount = 10;

	void Start () {
        RigidBody_A = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = mainColor;

        //adjusts acceleration so it's a reasonable value to input.
        accel = accel/100;

        
        invincible = false;

        Dyin = false;
        
	}

    // Update is called once per frame
    void Update()
    {

        //returns true or false: is the player's collider touching another collider on the specified layer (aka the ground)?

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        RigidBody_A.velocity = new Vector2(moveSpeed, RigidBody_A.velocity.y);

        //is the character jumping?

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {

            if (grounded) // is grounded true?
            {
                RigidBody_A.velocity = new Vector2(RigidBody_A.velocity.x, jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow) && grounded))
        {
            spriteRenderer.sprite = Duck;
            boxCollider.size = new Vector2(1, (float).5);
            boxCollider.offset = new Vector2(0, (float)-.25);

        } 
        else if (Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            spriteRenderer.sprite = Stand;
            boxCollider.size = new Vector2(1, 1);
            boxCollider.offset = new Vector2(0, 0);

        }

        //Accelerate velocity
        if (moveSpeed >= maxSpeed)
        {

            moveSpeed = maxSpeed;
 
        }
        else if (moveSpeed <= minSpeed)
        {
            //so it doesn't bounce. but delete doesn't release.
            if (moveSpeed < 0)
                moveSpeed = minSpeed;

            Debug.Log("Dying");


            //auto destroys anything under 1.
            if (moveSpeed < .5)
            {
                Dyin = false;
                Invoke("Destruction", 2);
            }
            else
            {
                Dyin = true;
            }

            //if you are dyin, you are slowin down. No need to worry about above if, cuz it won't ever be greater.
            if (Dyin)
            {
                moveSpeed = moveSpeed / 1.075f;
                Debug.Log(moveSpeed);
            }

            
        } else if (invincible) 
        {
            moveSpeed += 0;
        }
        else 
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

    }

    //Damage called from other objects
    public void SlowDown()
    {

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

    void Destruction()
    {
        Debug.Log("You are now Dead");
        Dyin = false;
        moveSpeed = 0;

        GameObject Manager = GameObject.Find("GameManager");
        GameManager managerial = Manager.GetComponent<GameManager>();
        managerial.GameOver();


    }

    private void LateUpdate()
    {
        //makes object flash when invincible
        if (invincible)
        {
            if (flashC < flashAmount) {
                spriteRenderer.color = flash;

            } else {
                spriteRenderer.color = mainColor;
            }

            if (flashC > flashAmount * 2) flashC = 0;
            flashC++;
        } else {
            spriteRenderer.color = mainColor;
        }
       
    }
}

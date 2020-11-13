using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public Rigidbody2D theRB;
    public float JumpForce;
    public float distance;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public LayerMask WhatIsLadder;

    private bool canDoubleJump;
    private bool isClimbing;

    private Animator anim;

    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement for the Player
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatIsGround);
        isClimbing = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

        //Used to determine if the player is able to jump or not
        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, JumpForce);
            }
            else
            {
                if(canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, JumpForce);
                    canDoubleJump = false;
                }
            }
        }

        if(isClimbing)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
                anim.SetBool("isClimbing", isClimbing);
            }
        }

        if(isClimbing == true)
        {

            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            theRB.velocity = new Vector2(theRB.velocity.x, climbSpeed * Input.GetAxis("Vertical"));
        }
        else
        {
            anim.SetBool("isClimbing", isClimbing);
            GetComponent<Rigidbody2D>().gravityScale = 4.5f;
        }

        //Switches the Player from left to right or right to left
        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

        //Used to give the player a crouch animation
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("isPressed", true);
            moveSpeed = 0;
            JumpForce = 0;
            Debug.Log("S button is pressed");
        }
        else if(Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("isPressed", false);
            moveSpeed = 5;
            JumpForce = 10;
            Debug.Log("S button is up");
        }
    }
}

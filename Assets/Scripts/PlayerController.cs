using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public Rigidbody2D theRB,theRB2;
    public float JumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

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
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

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

        /*
        if(Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            theRB2.velocity = new Vector2(theRB.velocity.x, climbSpeed * Input.GetAxis("Vertical"));
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().gravityScale = 4.5f;
        }
        */

        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetFloat("climbSpeed", Mathf.Abs(theRB.velocity.y));
        anim.SetBool("isGrounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isPressed", true);
            moveSpeed = 0;
            JumpForce = 0;
            Debug.Log("S button is pressed");
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isPressed", false);
            moveSpeed = 5;
            JumpForce = 10;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public float moveSpeed;

    public Transform leftpoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;

    public SpriteRenderer theSR;

    public float movetime, waitTime;

    private float moveCount, WaitCount;

    private Animator anim;

    public int health;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftpoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = movetime;

    }

    // Update is called once per frame
    void Update()
    {
        if (health != 0)
        {
            if (moveCount > 0)
            {
                moveCount -= Time.deltaTime;

                if (movingRight)
                {
                    theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                    theSR.flipX = true;

                    if (transform.position.x > rightPoint.position.x)
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                    theSR.flipX = false;


                    if (transform.position.x < leftpoint.position.x)
                    {
                        movingRight = true;
                    }
                }

                if (moveCount <= 0)
                {
                    WaitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
                }
                anim.SetBool("Moving", true);
            }
            else if (WaitCount > 0)
            {
                WaitCount -= Time.deltaTime;
                theRB.velocity = new Vector2(0f, theRB.velocity.y);
                if (WaitCount <= 0)
                {
                    moveCount = Random.Range(movetime * .75f, waitTime * .75f);
                }
                anim.SetBool("Moving", false);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

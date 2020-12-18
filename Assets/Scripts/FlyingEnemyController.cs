using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    public static FlyingEnemyController instance;
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public int health;

    public SpriteRenderer theSR;

    public float distanceToAttack;

    public float ChaseSpeed;

    private Vector3 attackTarger;

    public float waitAfterAttack;

    private float attackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health != 0)
        {
            if (attackCounter > 0)
            {
                attackCounter -= Time.deltaTime;
            }
            else
            {
                if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttack)
                {
                    attackTarger = Vector3.zero;

                    transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, points[currentPoint].position) < .05)
                    {
                        currentPoint++;

                        if (currentPoint >= points.Length)
                        {
                            currentPoint = 0;
                        }
                    }

                    if (transform.position.x < points[currentPoint].position.x)
                    {
                        theSR.flipX = true;
                    }
                    else if (transform.position.x > points[currentPoint].position.x)
                    {
                        theSR.flipX = false;
                    }
                }
                else
                {
                    //Attacking the player

                    if (transform.position.x < PlayerController.instance.transform.position.x)
                    {
                        theSR.flipX = true;
                    }
                    else if (transform.position.x > PlayerController.instance.transform.position.x)
                    {
                        theSR.flipX = false;
                    }

                    if (attackTarger == Vector3.zero)
                    {
                        attackTarger = PlayerController.instance.transform.position;
                    }
                    transform.position = Vector3.MoveTowards(transform.position, attackTarger, ChaseSpeed * Time.deltaTime);

                    if (Vector3.Distance(transform.position, attackTarger) <= .1f)
                    {
                        attackCounter = waitAfterAttack;
                        attackTarger = Vector3.zero;
                    }

                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

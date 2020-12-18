using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncepad_Down : MonoBehaviour
{
    public Animator anim;

    public float BounceForce = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.theRB.velocity = new Vector2(PlayerController.instance.theRB.velocity.x, -BounceForce);
            anim.SetTrigger("Bounce");
        }
    }
}

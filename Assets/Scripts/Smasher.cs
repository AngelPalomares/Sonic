using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(Smashing());
        }
    }
    
    public IEnumerator Smashing()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetBool("Hammer", true);

        yield return new WaitForSeconds(2f);
        anim.SetBool("Hammer", false);
    }
}

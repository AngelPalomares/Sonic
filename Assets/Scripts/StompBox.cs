using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deatheffect;

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
        if(collision.tag == "Enemy")
        {
            Debug.Log("Bonk");

            collision.transform.parent.gameObject.SetActive(false);

            Instantiate(deatheffect, collision.transform.position, collision.transform.rotation);

            PlayerController.instance.Bounce();
        }
    }
}

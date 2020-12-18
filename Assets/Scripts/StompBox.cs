using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deatheffect;

    public GameObject collectible;

    [Range(0, 100)] public float chanceToDrop;

    public int Audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //stompbox is used to destroy enemies
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Frog")
        {
            Debug.Log("Bonk");

            EnemyController.instance.health--;

            Instantiate(deatheffect, collision.transform.position, collision.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, collision.transform.position, collision.transform.rotation);
            }

            AudioManager.instance.PlaySFX(Audio);
        }
        else if(collision.tag == "Eagle")
        {
            FlyingEnemyController.instance.health--;

            Instantiate(deatheffect, collision.transform.position, collision.transform.rotation);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);

            if (dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, collision.transform.position, collision.transform.rotation);
            }

            AudioManager.instance.PlaySFX(Audio);
        }
    }
}

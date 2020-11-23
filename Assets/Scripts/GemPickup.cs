using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    public bool isGem, isheal;

    private bool isCollected;

    public static GemPickup instace;

    public GameObject pickupEffect;

    private void Awake()
    {
        instace = this;
    }

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
        if(collision.CompareTag("Player")&& !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;

                isCollected = true;

                Destroy(gameObject);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.addlife();
                UIController.instance.UpdateGemCount();
            }

            if(isheal)
            {
                if(PlayerHealthController.instance.CurrentHealth != PlayerHealthController.instance.MaxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true;
                    Destroy(gameObject);

                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}

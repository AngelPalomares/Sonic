using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int MaxHealth;
    public int CurrentHealth;

    public float invincibleLength;

    private float invincibleCounter;

    private SpriteRenderer theSr;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        theSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, 1f);
            }
        }
    }

    //Deals Damage to Player
    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            CurrentHealth--;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, .5f);

                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        //CurrentHealth = MaxHealth;
        CurrentHealth++;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}

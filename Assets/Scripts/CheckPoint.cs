using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite cpon, cpoff;
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
        if(collision.CompareTag("Player"))
        {
            CheckPointController.instance.DeactivateCheckpoints();

            theSR.sprite = cpon;

            CheckPointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        theSR.sprite = cpoff;
    }
}

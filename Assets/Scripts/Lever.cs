using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject objectToSwitch;

    public SpriteRenderer theSR;
    public Sprite downSprite;

    private bool hasSwitched;

    public bool deactivateOnSwitch;

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
        if(collision.tag == "Player" && !hasSwitched)
        {

            if (deactivateOnSwitch)
            {
                objectToSwitch.SetActive(false);
            }else
            {
                objectToSwitch.SetActive(true);
            }

            theSR.sprite = downSprite;

            hasSwitched = true;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3;

    public Sprite heartfull, halfheart, emptyheart;

    public Text Lives;

    public int counter;

    public Text Gems;

    public Image Fadescreen;

    public float FadeSpeed;

    private bool FadeToBlack, FadeFromWhite;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Lives.text = counter.ToString();
        UpdateGemCount();
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeToBlack)
        {
            Fadescreen.color = new Color(Fadescreen.color.r, Fadescreen.color.g, Fadescreen.color.b, Mathf.MoveTowards(Fadescreen.color.a, 1f, FadeSpeed * Time.deltaTime));
            if(Fadescreen.color.a == 1f)
            {
                FadeToBlack = false;
            }    
        }
        
        if(FadeFromWhite)
        {
            Fadescreen.color = new Color(Fadescreen.color.r, Fadescreen.color.g, Fadescreen.color.b, Mathf.MoveTowards(Fadescreen.color.a, 0f, FadeSpeed * Time.deltaTime));
            if (Fadescreen.color.a == 0f)
            {
                FadeFromWhite = true;
            }
        }
    }
    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.CurrentHealth)
        {
            case 6:
                heart1.sprite = heartfull;
                heart2.sprite = heartfull;
                heart3.sprite = heartfull;
                break;

            case 5:
                heart1.sprite = heartfull;
                heart2.sprite = heartfull;
                heart3.sprite = halfheart;
                break;

            case 4:
                heart1.sprite = heartfull;
                heart2.sprite = heartfull;
                heart3.sprite = emptyheart;
                break;

            case 3:
                heart1.sprite = heartfull;
                heart2.sprite = halfheart;
                heart3.sprite = emptyheart;
                break;

            case 2:
                heart1.sprite = heartfull;
                heart2.sprite = emptyheart;
                heart3.sprite = emptyheart;
                break;

            case 1:
                heart1.sprite = halfheart;
                heart2.sprite = emptyheart;
                heart3.sprite = emptyheart;
                break;

            case 0:
                heart1.sprite = emptyheart;
                heart2.sprite = emptyheart;
                heart3.sprite = emptyheart;
                break;

        }
    }

    public void Livess()
    {
        counter--;
        Lives.text = counter.ToString();
    }

    public void addlife()
    {
        if(LevelManager.instance.gemsCollected == 25 || LevelManager.instance.gemsCollected == 50)
        {
            counter++;
            Lives.text = counter.ToString();
        }
    }

    public void UpdateGemCount()
    {
        Gems.text = LevelManager.instance.gemsCollected.ToString();
    }

    public void FadeT0oBlack()
    {
        FadeToBlack = true;
        FadeFromWhite = false;
    }

    public void FadeFromBlack()
    {
        FadeFromWhite = true;
        FadeToBlack = false;
    }

}

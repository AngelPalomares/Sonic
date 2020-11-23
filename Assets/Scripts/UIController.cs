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

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Lives.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGemCount();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUiCOntroller : MonoBehaviour
{
    public static LevelSelectUiCOntroller instance;

    public Image Fadescreen;

    public float FadeSpeed;

    private bool FadeToBlack, FadeFromWhite;

    public GameObject LevelInfoPanel;

    public Text LevelName, GemsFound,GemsTarget,BestTime,TimeTarget;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (FadeToBlack)
        {
            Fadescreen.color = new Color(Fadescreen.color.r, Fadescreen.color.g, Fadescreen.color.b, Mathf.MoveTowards(Fadescreen.color.a, 1f, FadeSpeed * Time.deltaTime));
            if (Fadescreen.color.a == 1f)
            {
                FadeToBlack = false;
            }
        }

        if (FadeFromWhite)
        {
            Fadescreen.color = new Color(Fadescreen.color.r, Fadescreen.color.g, Fadescreen.color.b, Mathf.MoveTowards(Fadescreen.color.a, 0f, FadeSpeed * Time.deltaTime));
            if (Fadescreen.color.a == 0f)
            {
                FadeFromWhite = true;
            }
        }
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

    public void ShowInformation(MapPoint levelinformation)
    {
        LevelName.text = levelinformation.LevelName;
        GemsFound.text = "FOUND: " + levelinformation.gemsCollected;
        GemsTarget.text = "IN LEVEL: " + levelinformation.totalGems;

        TimeTarget.text = "TARGET: " + levelinformation.TargetTime + "s";

        if(levelinformation.BestTime == 0)
        {
            BestTime.text = "BEST: ---";
        }
        else
        {
            BestTime.text = "BEST: " + levelinformation.BestTime.ToString("F1") + "s";
        }

        LevelInfoPanel.SetActive(true);
    }

    public void HideInformation()
    {
        LevelInfoPanel.SetActive(false);
    }
}

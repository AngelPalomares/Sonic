using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public static MapPoint instance;

    public MapPoint up, right, down, left;
    public bool islevel;

    public bool islocked;

    public string leveltoload, leveltoCheck, LevelName;

    public int gemsCollected, totalGems;
    public float BestTime, TargetTime;

    public GameObject gembadge, timebadge;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (islevel && leveltoload != null)
        {
            if (PlayerPrefs.HasKey(leveltoload + "_gems"))
                gemsCollected = PlayerPrefs.GetInt(leveltoload + "_gems");

            if (PlayerPrefs.HasKey(leveltoload + "_time"))
                BestTime = PlayerPrefs.GetFloat(leveltoload + "_time");

            if(gemsCollected >= totalGems)
            {
                gembadge.SetActive(true);
            }    

            if(BestTime <= TargetTime && BestTime != 0)
            {
                timebadge.SetActive(true);
            }

            islocked = true;
            if(leveltoCheck != null)
            {
                if (PlayerPrefs.HasKey(leveltoCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(leveltoCheck + "_unlocked") == 1)
                    {
                        islocked = false;
                    }
                } 
            }
            if(leveltoload == leveltoCheck)
            {
                islocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

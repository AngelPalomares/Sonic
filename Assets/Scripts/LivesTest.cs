using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTest : MonoBehaviour
{
    public static LivesTest instance;
    public int counter;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.Lives.text = counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Livess()
    {
        counter--;
        UIController.instance.Lives.text = counter.ToString();
    }

    public void addlife()
    {
        if (LevelManager.instance.gemsCollected == 25 || LevelManager.instance.gemsCollected == 50)
        {
            counter++;
            UIController.instance.Lives.text = counter.ToString();
        }
    }
}

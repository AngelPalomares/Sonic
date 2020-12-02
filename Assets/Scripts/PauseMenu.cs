using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public int MainMenu;
    public int LevelSelct;

    public GameObject PauseScreen;

    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            PauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            PauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(LevelSelct);
        Time.timeScale = 1f;
    }

    public void MainMenuselect()
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }
}

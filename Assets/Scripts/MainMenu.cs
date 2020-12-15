using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartScene, ContinueScene;

    public GameObject continueButton;

    void Start()
    {
        if (PlayerPrefs.HasKey(StartScene + "_unlocked"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

    }
    public void StartGane()
    {
        SceneManager.LoadScene(StartScene);

        PlayerPrefs.DeleteAll();
    }

    public void LetsContinue()
    {
        SceneManager.LoadScene(ContinueScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int loading;
    public void StartGane()
    {
        SceneManager.LoadScene(loading);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

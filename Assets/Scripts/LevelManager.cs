using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int gemsCollected;

    public int LevelToLoad;

    public int LevelMusic;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayBGM(LevelMusic);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
      
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.FadeSpeed));

        UIController.instance.FadeT0oBlack();

        yield return new WaitForSeconds((1f / UIController.instance.FadeSpeed) + .2f);

        UIController.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckPointController.instance.spawnpoint;

        PlayerHealthController.instance.CurrentHealth = PlayerHealthController.instance.MaxHealth;

        UIController.instance.UpdateHealthDisplay();

        UIController.instance.Livess();
    }

    public void ENdLevel()
    {
        StartCoroutine(EndLevelCO());
    }

    public IEnumerator EndLevelCO()
    {
        AudioManager.instance.PlayBGM(3);

        PlayerController.instance.StopInput = true;

        CameraController.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UIController.instance.FadeT0oBlack();

        yield return new WaitForSeconds((1f / UIController.instance.FadeSpeed) + .25f);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(LevelToLoad);
    }

}

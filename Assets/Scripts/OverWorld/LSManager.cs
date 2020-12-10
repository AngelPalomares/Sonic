using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    public static LSManager instance;
    public LS_Player theplayer;

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
        
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        LevelSelectUiCOntroller.instance.FadeT0oBlack();

        Debug.Log("Testing");
        yield return new WaitForSeconds((1f / LevelSelectUiCOntroller.instance.FadeSpeed) * .25f);

        SceneManager.LoadScene(theplayer.currentPoint.leveltoload);
    }
}

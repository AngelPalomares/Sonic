using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffects;

    public AudioSource StartMusic;

    public AudioSource EndMusic;

    //public AudioSource[] BGM;

    //public AudioSource bgm, LevelEndMusic;

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

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.8f, 1.1f);

        soundEffects[soundToPlay].Play();
    }

    /*
    public void PlayBGM(int playBGM)
    {
        BGM[playBGM].Stop();

        BGM[playBGM].Play();
    }
    */

    public void LevelEndMusic()
    {
        StartMusic.Stop();
        EndMusic.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;
    public AudioClip mainTheme;
    public AudioClip startButton;
    public AudioClip swoosh1;
    public AudioClip QCorrect;
    public AudioClip QWrong;
    public AudioClip DMove;
    public AudioClip DLose;
    public AudioClip DWin;
    public AudioClip BGo;
    public AudioClip BLose;
    public AudioClip BWin;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip soundeffect){
        audioSource.PlayOneShot(soundeffect, .7f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    AudioSource audioSource;
    public AudioClip mainTheme;
    public AudioClip startButton;
    public AudioClip swoosh1;
    // Start is called before the first frame update
    void Awake()
    {
        if (audioManager != null && audioManager != this)
        {
            Destroy(this);
        }
        else
        {
            audioManager = this;
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

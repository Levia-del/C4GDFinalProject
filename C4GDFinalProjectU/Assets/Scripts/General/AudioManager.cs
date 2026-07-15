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
    public AudioClip DLose;
    public AudioClip DWin;
    public AudioClip BGo;
    public AudioClip BLose;
    public AudioClip BWin;
    public AudioClip Cheer;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Get or create AudioSource as early as possible
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySFX(AudioClip soundeffect, float volume)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioManager: AudioSource is null. Creating one.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (soundeffect == null)
        {
            Debug.LogWarning("AudioManager: Attempted to play a null AudioClip.");
            return;
        }

        audioSource.PlayOneShot(soundeffect, volume);
    }

    public void PlayMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
        
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}

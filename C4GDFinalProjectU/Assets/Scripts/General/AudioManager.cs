using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource audioSource;
    AudioSource themeAudioSource;
    AudioSource percussionAudioSource;
    public AudioClip mainTheme;
    public AudioClip percussion;
    public AudioClip startButton;
    public AudioClip swoosh1;
    public AudioClip QCorrect;
    public AudioClip QWrong;
    public AudioClip BGo;
    public AudioClip Cheer;
    public AudioClip clockTick;
    public AudioClip rockFall;
    public AudioClip crowdBoo;
    public AudioClip GeneralLose;
    public AudioClip GeneralWin;
    public AudioClip heartBreak;

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
            themeAudioSource = gameObject.AddComponent<AudioSource>();
            percussionAudioSource = gameObject.AddComponent<AudioSource>();
        }
        themeAudioSource.loop = true;
        percussionAudioSource.loop = true;

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

    public void PlayThemeMelody(float volume)
    {
        if (themeAudioSource.isPlaying)
        {

            themeAudioSource.DOFade(volume, .5f);
        }
        else
        {
            themeAudioSource.clip = mainTheme;
            themeAudioSource.DOFade(volume, .5f);
            themeAudioSource.Play();
        }
    }

    public void PlayThemePercussion(float volume)
    {
        if (percussionAudioSource.isPlaying)
        {
            percussionAudioSource.DOFade(volume, .5f);
        }
        else
        {
            percussionAudioSource.clip = percussion;
            percussionAudioSource.DOFade(volume, .5f);
            percussionAudioSource.Play();
        }
        
    }
}

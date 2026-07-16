using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartScrn : MonoBehaviour
{
    public Button btn;
    bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(SG);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SG()
    {
        if (isClicked == true) return;

        
        isClicked = true;
        btn.interactable = false;
        
        AudioManager.instance.PlayThemeMelody(0f);
        AudioManager.instance.PlayThemePercussion(1f);
        AudioManager.instance.PlaySFX(AudioManager.instance.Cheer, .7f);
        AudioManager.instance.PlaySFX(AudioManager.instance.startButton, .5f);
        LevelsManager.instance.LevelComplete(true);
    }

    
}

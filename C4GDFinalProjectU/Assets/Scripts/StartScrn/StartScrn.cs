using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartScrn : MonoBehaviour
{
    public Button btn;
    public RectTransform rcurtain;
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

        StartCoroutine(StartGame());
        MainGameUI.instance.newLevel();
        isClicked = true;
        btn.GetComponent<Button>().interactable = false;
    }

    IEnumerator StartGame()
    {
        AudioManager.instance.PlayThemeMelody(0f);
        AudioManager.instance.PlayThemePercussion(1f);
        AudioManager.instance.PlaySFX(AudioManager.instance.Cheer, .7f);
        AudioManager.instance.PlaySFX(AudioManager.instance.startButton, .5f);
        rcurtain.DOMoveY(550, 1f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Transition");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartScrn : MonoBehaviour
{
    public Button btn;
    public Image fadeImage;
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
        isClicked = true;
        btn.GetComponent<Button>().interactable = false;
    }

    IEnumerator StartGame()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.Cheer, 1);
        AudioManager.instance.PlaySFX(AudioManager.instance.startButton, .3f);
        fadeImage.DOFade(1, 2.5f);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Transition");
    }
}

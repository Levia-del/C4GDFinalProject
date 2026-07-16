using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class DeathCanvas : MonoBehaviour
{
    public Button btn;

    [Header("Score Display")]
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Restart);
        btn.transform.position = new Vector3(btn.transform.position.x, -650, 0);
        AudioManager.instance.PlaySFX(AudioManager.instance.deathScreen, 1f);
        AudioManager.instance.PlayThemePercussion(0f);
        StartCoroutine(buttonApear());

        // Display scores
        if (finalScoreText != null)
            finalScoreText.text = "Score: " + HighScore.CurrentScore;
        if (highScoreText != null)
            highScoreText.text = "Best: " + HighScore.GetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator buttonApear()
    {
        yield return new WaitForSeconds(1);
        btn.transform.DOMoveY(200, 2f);
    }
}

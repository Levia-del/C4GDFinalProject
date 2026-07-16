using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ButtonCanvas : MonoBehaviour
{
    public Button btn;
    public TMP_Text txt;
    public GameObject hand;

    private float waitTime;
    private float reactionTime;
    private bool isGo = false;
    private bool finished = false;

    private Vector3 originalScale;
    private Coroutine pulseCoroutine;
    private Coroutine colorFlashCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Wait";
     
        btn.image.color = Color.white;
        originalScale = btn.transform.localScale;

        // Random wait duration between 3 and 15 seconds
        waitTime = Random.Range(1f, 10f);

        // Wire up button click
        btn.onClick.AddListener(OnButtonClicked);

        AudioManager.instance.PlayMusic(AudioManager.instance.clockTick);
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;

        if (!isGo)
        {
            // Wait phase — counting down to "Go!"
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                txt.text = "Go!";
                btn.interactable = true;
                isGo = true;
                AudioManager.instance.PlaySFX(AudioManager.instance.BGo, 1.5f);
                // Reaction window starts at 5s, decreases with level, minimum 1s
                reactionTime = Mathf.Max(3f - (LevelsManager.instance.levelNmbr*0.5f), .5f);

                // Start pulsating scale and color flash effects
                StartVisualEffects();
            }
        }
        else
        {
            // Reaction phase — player must click before timer expires
            if (reactionTime > 0)
            {
                reactionTime -= Time.deltaTime;
            }
            else
            {
                StopVisualEffects();
                AudioManager.instance.StopMusic();
                finished = true;
              
                txt.text = "Too Slow!";
                AudioManager.instance.PlaySFX(AudioManager.instance.GeneralLose, 2f);
                AudioManager.instance.PlaySFX(AudioManager.instance.crowdBoo, 1f);
                btn.image.color = Color.white;
                MainGameUI.instance.TakeDamage();
                StartCoroutine(AdvanceAfterDelay());
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonClicked();
        }
    }

    void StartVisualEffects()
    {
        // Reset scale to baseline before starting pulse
        btn.transform.localScale = originalScale;

        // Pulsating scale using manual localScale with sine-wave oscillation
        pulseCoroutine = StartCoroutine(PulseScale());

        // Start randomized color flashing
        colorFlashCoroutine = StartCoroutine(FlashColors());
    }

    void StopVisualEffects()
    {
        // Stop the pulse coroutine
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
        }

        // Stop the color flash coroutine
        if (colorFlashCoroutine != null)
        {
            StopCoroutine(colorFlashCoroutine);
            colorFlashCoroutine = null;
        }

        // Kill any remaining color tweens on the button image
        btn.image.DOKill();

        // Reset to default visual state
        btn.transform.localScale = originalScale;
        btn.image.color = Color.white;
    }

    IEnumerator PulseScale()
    {
        float minFactor = 1.0f;
        float maxFactor = 1.2f;
        float frequency = 2.5f; // full pulse cycles per second

        while (true)
        {
            // Sine wave: goes from 0 → 1 → 0 smoothly
            float t = (Mathf.Sin(Time.time * frequency * Mathf.PI * 2f) + 1f) * 0.5f;
            float factor = Mathf.Lerp(minFactor, maxFactor, t);
            btn.transform.localScale = new Vector3(
                originalScale.x * factor,
                originalScale.y * factor,
                originalScale.z
            );
            yield return null;
        }
    }

    IEnumerator FlashColors()
    {
        while (true)
        {
            // Pick a random vibrant color (avoiding extremes for readability)
            Color randomColor = new Color(
                Random.Range(0.2f, 1f),
                Random.Range(0.2f, 1f),
                Random.Range(0.2f, 1f)
            );
            btn.image.DOColor(randomColor, 0.3f).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnButtonClicked()
    {
        AudioManager.instance.StopMusic();
        if (finished)
        {
            return;
        }
        Instantiate(hand);
        if (!isGo)
        {
            StopVisualEffects();
            finished = true;

            txt.text = "Not Yet!";
            AudioManager.instance.PlaySFX(AudioManager.instance.GeneralLose, 2f);
            AudioManager.instance.PlaySFX(AudioManager.instance.crowdBoo, 1f);
            btn.image.color = Color.white;
            MainGameUI.instance.TakeDamage();
            StartCoroutine(AdvanceAfterDelay());
        }
        else
        {
            StopVisualEffects();
            finished = true;
            AudioManager.instance.PlaySFX(AudioManager.instance.Cheer, 1f);
            AudioManager.instance.PlaySFX(AudioManager.instance.GeneralWin, .5f);
            txt.text = "Got it!";
            btn.image.color = Color.white;
            StartCoroutine(AdvanceAfterDelay());
        }
        

       
    }

    IEnumerator AdvanceAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        LevelsManager.instance.LevelComplete(true);
    }
}

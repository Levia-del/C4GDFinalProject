using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class MainGameUI : MonoBehaviour
{
    public static MainGameUI instance;
    public GameObject curtn;
    public RectTransform Rcurtn;
    public GameObject[] hearts;
    public int health = 3;
    public TMP_Text NLTXT;

 

    void Start()
    {
        
        curtn.SetActive(false);
        Rcurtn = curtn.GetComponent<RectTransform>();



        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        for(int i = 0;i< hearts.Length;i++)
        {
            hearts[i].SetActive(false);
        }
        for(int i = 0;i<health;i++)
        {
            hearts[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    /// <summary>
    /// Deals damage: decrements health, animates the last active heart
    /// flying to screen center and exploding, then disables it.
    /// </summary>
    public void TakeDamage()
    {
        if (health <= 0) return;

        // Find the last active heart (highest index with active GameObject)
        int lastHeartIndex = -1;
        for (int i = hearts.Length - 1; i >= 0; i--)
        {
            if (hearts[i] != null && hearts[i].activeSelf)
            {
                lastHeartIndex = i;
                break;
            }
        }

        health--;

        if (lastHeartIndex >= 0 && hearts[lastHeartIndex] != null)
        {
            StartCoroutine(AnimateHeartToCenter(hearts[lastHeartIndex]));
        }
    }

    /// <summary>
    /// Coroutine: flies a heart GameObject to screen center, scales it up,
    /// then plays a placeholder "explosion" (scale burst + fade out).
    /// </summary>
    IEnumerator AnimateHeartToCenter(GameObject heart)
    {
        RectTransform heartRect = heart.GetComponent<RectTransform>();
        Image heartImage = heart.GetComponent<Image>();
        if (heartRect == null) yield break;

        // Store original state for restoring afterwards
        Vector2 startPos = heartRect.anchoredPosition;
        Vector3 startScale = heart.transform.localScale;
        Color startColor = heartImage != null ? heartImage.color : Color.white;
        Vector2 centerPos = Vector2.zero; // (0,0) in anchored position = canvas center

        // ── Phase 1: Fly to center (0.5s) with smooth easing ──
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (heart == null) yield break;

            float t = elapsed / duration;
            // Smooth step: t²(3-2t) for natural acceleration & deceleration
            float smoothT = t * t * (3f - 2f * t);

            heartRect.anchoredPosition = Vector2.Lerp(startPos, centerPos, smoothT);
            heart.transform.localScale = Vector3.Lerp(startScale, startScale * 1.8f, smoothT);

            elapsed += Time.deltaTime;
            yield return null;
        }

        if (heart == null) yield break;
        heartRect.anchoredPosition = centerPos;
        heart.transform.localScale = startScale * 1.8f;



        // ── Phase 2: Placeholder "explosion" (0.4s) ──
        //   - 0-30%:   scale bursts up to 3.5x
        //   - 30-100%: scale shrinks to 0 while fading alpha
        duration = 0.4f;
        elapsed = 0f;
        Vector3 maxScale = startScale * 3.5f;
        StartCoroutine(Flash());
        while (elapsed < duration)
        {
            if (heart == null) yield break;

            float t = elapsed / duration;

            // Scale: quick burst then collapse
            float scaleT;
            if (t < 0.3f)
                scaleT = t / 0.3f;          // 0 → 1 in first 30%
            else
                scaleT = 1f - (t - 0.3f) / 0.7f; // 1 → 0 in remaining 70%

            heart.transform.localScale = Vector3.Lerp(startScale * 1.8f, maxScale, scaleT);

            // Fade out alpha
            if (heartImage != null)
                heartImage.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, t));

            elapsed += Time.deltaTime;
            yield return null;
        }




        

        

        // Final cleanup
        if (heart != null)
        {
            heart.SetActive(false);
            if (heartImage != null) heartImage.color = startColor;
            heart.transform.localScale = startScale;
            heartRect.anchoredPosition = startPos;
        }
    }


    IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.2f);
        // ── Screen Flash: quick white flash right before explosion ──
        GameObject flashOverlay = new GameObject("DamageFlash", typeof(Image));
        RectTransform flashRect = flashOverlay.GetComponent<RectTransform>();
        Image flashImage = flashOverlay.GetComponent<Image>();

        // Attach to the same canvas
        flashOverlay.transform.SetParent(transform, false);
        flashRect.anchorMin = Vector2.zero;
        flashRect.anchorMax = Vector2.one;
        flashRect.offsetMin = Vector2.zero;
        flashRect.offsetMax = Vector2.zero;
        flashImage.color = new Color(1f, 0f, 0f, 0f);
        flashImage.raycastTarget = false;

        // Flash on: quickly fade to red
        float flashDuration = 0.1f;
        float flashElapsed = 0f;
        while (flashElapsed < flashDuration)
        {
            float t = flashElapsed / flashDuration;
            flashImage.color = new Color(1f, 0f, 0f, t);
            flashElapsed += Time.deltaTime;
            yield return null;
        }
        flashImage.color = new Color(1f, 0f, 0f, 1f);

        // Flash off: quickly fade back to clear
        flashElapsed = 0f;
        while (flashElapsed < flashDuration)
        {
            float t = flashElapsed / flashDuration;
            flashImage.color = new Color(1f, 0f, 0f, 1f - t);
            flashElapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(flashOverlay);
    }

    
    

    public void newLevel()
    {
        if(health<1)
        {
            SceneManager.LoadScene("DeathScreen");
            Destroy(gameObject);
            Destroy(LevelsManager.instance.gameObject);
        }
        else
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(false);
            }
            for (int i = 0; i < health; i++)
            {
                hearts[i].SetActive(true);
            }
            curtn.SetActive(true);
            Rcurtn.DOMoveY(550, 2f).OnComplete(() =>
            {
                curtn.SetActive(false);
            });
        }
    }

    public void setNLTXT(string txt)
    {
        NLTXT.text = txt;
    }
}

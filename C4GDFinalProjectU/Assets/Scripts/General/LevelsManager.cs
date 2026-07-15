using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;

    private string[] levels = {"Questions", "Dodge", "Button"};

    public int currLvl = -1;
    public int nextLvl;
    public int levelNmbr = 0;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
        currLvl = generateRadnLvl();
        nextLvl = generateRadnLvl();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    int generateRadnLvl()
    {
        int lvl = Random.Range(0, levels.Length);
        while(lvl==currLvl)
        {
            lvl = Random.Range(0, levels.Length);
        }
        return lvl;
    }

    public void LevelComplete(bool isTransition)
    {
        if (isTransition)
        {
            // Curtain close + transition handled in coroutine

            MainGameUI.instance.newLevel();
            StartCoroutine(TransitionWithCurtain());
        }
        else
        {
            MainGameUI.instance.Rcurtn.anchoredPosition = new Vector2(0, 0);
            MainGameUI.instance.curtn.SetActive(true);
            MainGameUI.instance.setNextVis(true);
            SceneManager.LoadScene(levels[nextLvl]);
            currLvl = nextLvl;
            nextLvl = generateRadnLvl();
            levelNmbr++;
            MainGameUI.instance.setNLTXT("Next level is: \n"+levels[nextLvl]);
            MainGameUI.instance.Rcurtn.DOMoveY(1600, 1f).OnComplete(() =>
            {
                MainGameUI.instance.curtn.SetActive(false);
                
            });
        }
    }

    IEnumerator TransitionWithCurtain()
    {
        yield return new WaitForSeconds(1.9f);
        SceneManager.LoadScene("Transition");
        MainGameUI.instance.setNextVis(false);
    }
    
}

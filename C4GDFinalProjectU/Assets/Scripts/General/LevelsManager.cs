using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;

    private string[] levels = {"Questions", "Dodge", "Button"};

    public int currLvl = -1;
    public int nextLvl;
    public int levelNmbr = 0;
    // Start is called before the first frame update

    
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
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
            SceneManager.LoadScene(levels[nextLvl]);
            currLvl = nextLvl;
            nextLvl = generateRadnLvl();
            levelNmbr++;
            MainGameUI.instance.setNLTXT("Next level is: "+levels[nextLvl]);
        }
    }

    IEnumerator TransitionWithCurtain()
    {
        // Reset hearts first
       

        // Animate curtain down and wait for it to finish
        

        // Brief pause with curtain covering, then load transition
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Transition");
    }
}

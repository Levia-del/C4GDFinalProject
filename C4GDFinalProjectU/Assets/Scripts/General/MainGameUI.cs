using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    public static MainGameUI instance;
    public GameObject[] hearts;
    public int health = 3;
    public TMP_Text NLTXT;

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

    public void newLevel()
    {
        if(health<1)
        {
            SceneManager.LoadScene("DeathScreen");
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
        }
        

    }

    public void setNLTXT(string txt)
    {
        NLTXT.text = txt;
    }
}

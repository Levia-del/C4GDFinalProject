using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUI : MonoBehaviour
{
    public static MainGameUI instance;
    public GameObject[] hearts;
    public int health = 3;

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
}

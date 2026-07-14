using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransitionCanvas : MonoBehaviour
{
    public LevelsManager LvlManager;
    public TMP_Text instTXT;
    public float waitTime = 5f;

    private float wait = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        LvlManager = LevelsManager.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }
        else
        {
            string mess="";
            if (LvlManager.currLvl == 0)
            {
                mess = "Answer correctly with A-D or die!";
            }
            else if (LvlManager.currLvl == 1)
            {
                mess = "Dodge with A-D or die!";
            }
            instTXT.text = mess;
        }

        if(wait <=0)
        {
            if(waitTime>0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                LvlManager.LevelComplete(false);
            }
        }
    }
}

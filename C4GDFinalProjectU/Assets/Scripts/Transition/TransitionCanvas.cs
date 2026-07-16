using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransitionCanvas : MonoBehaviour
{
    public LevelsManager LvlManager;
    public TMP_Text instTXT;
    public float waitTime = 2f;
    public RectTransform rcurtain;

    private float wait = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        LvlManager = LevelsManager.instance;
        waitTime = Mathf.Max(5 - (LvlManager.levelNmbr / 2), 1f);
        
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
            if (LvlManager.nextLvl == 0)
            {
                mess = "Answer fast or die!\n(A<->D)";
            }
            else if (LvlManager.nextLvl == 1)
            {
                mess = "Dodge or die!\n(A<->D)";
            }
            else if (LvlManager.nextLvl == 2)
            {
                mess = "When I say GO! press the button\n(SPACE)";
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

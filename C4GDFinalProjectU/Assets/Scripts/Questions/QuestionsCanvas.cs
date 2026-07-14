using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionsCanvas : MonoBehaviour
{
    public TMP_Text QTXT;
    public Button BTNL, BTNR;
    public LevelsManager LvlManager;
    public TMP_Text LTXT;
    public TMP_Text RTXT;

    private string[] easyQs = {"Who is the best gameshow host?","What game are we playing?","What is your reward?","How do you win?"};
    private string[] mediumQs = {"What is the capital of Australia?", "What state am I from?", "What do you love about me?"};
    private string[] hardQs = {"Why are you here?", "Why.", "What is the meaning of life?"};

    Dictionary<string, string[]> As = new Dictionary<string, string[]>()
    {
        {"Who is the best gameshow host?", new string[]{"Steve \nHarley","IDK"} },
        {"What game are we playing?", new string[]{"Family \nFeud","Help! \nISIAKG"} },
        {"What is your reward?", new string[]{"A Million \nDollars","More \nMinigames!"} },
        {"How do you win?", new string[]{"You Don't","Survive \n10 Minigames"} },
        {"What is the capital of Australia?", new string[]{"Sydney","Canberra"} },
        {"What state am I from?", new string[]{"West \nVirginia","New \nJersey"} },
        {"What do you love about me?", new string[]{"Mustache","Hair"} },
        {"Why are you here?", new string[]{"To suffer.","To get \nthe rating up!"} },
        {"Why.", new string[]{"...","...."} },
        {"What is the meaning of life?", new string[]{"To live","to Live"} }
    };

    Dictionary<string, bool> BoolAs = new Dictionary<string, bool>()
    {
        {"Who is the best gameshow host?", false },
        {"What game are we playing?", true},
        {"What is your reward?", true},
        {"How do you win?", false},
        {"What is the capital of Australia?", true},
        {"What state am I from?", false},
        {"What do you love about me?", false},
        {"Why are you here?", true},
        {"Why.", true},
        {"What is the meaning of life?.", false}
        
    };

    private bool isRight = true;
    // Start is called before the first frame update

    void Start()
    {
        
        string q = "";
        LvlManager = LevelsManager.instance;

        if (LvlManager.levelNmbr < 3)
        {
            q = easyQs[Random.Range(0, easyQs.Length)];
        }
        else if(LvlManager.levelNmbr < 6)
        {
            q = mediumQs[Random.Range(0, mediumQs.Length)];
        }
        else
        {
            q = hardQs[Random.Range(0, hardQs.Length)];
        }

        QTXT.text = q;
        LTXT.text = As[q][0];
        RTXT.text = As[q][1];
        isRight = BoolAs[q];

        BTNL.onClick.AddListener(LBClicked);
        BTNR.onClick.AddListener(RBClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        { answerProcess(!isRight); } 
        else if (Input.GetKeyDown(KeyCode.D)) 
        { answerProcess(isRight); }
    }

  

    void LBClicked()
    {
        answerProcess(!isRight);
    }

    void RBClicked()
    {
        answerProcess(isRight);
    }

    void answerProcess(bool condition)
    {
        if (condition)
        {
            QTXT.text = "Correct!";
            StartCoroutine(NxtLvl());

        }
        else
        {
            QTXT.text = "Nope. Death!";
            MainGameUI.instance.health--;
            StartCoroutine(NxtLvl());
        }
    }

    IEnumerator NxtLvl()
    {
        yield return new WaitForSeconds(2f);
        LvlManager.LevelComplete(true);
    }
}

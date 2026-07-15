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
    public GameObject QWrong, QRight;

    private string[] easyQs = {"Who is the best gameshow host?","What game are we playing?","What is your reward?","How do you win?"};
    private string[] mediumQs = {"What is the capital of Australia?", "What state am I from?", "What do you love about me?"};
    private string[] hardQs = {"Why are you here?", "Why.", "What is the meaning of life?"};

    private bool finished = false;
    private float timer = 5f;

    Dictionary<string, string[]> As = new Dictionary<string, string[]>()
    {
        {"Who is the best gameshow host?", new string[]{"Steve \nHarvey","IDK"} },
        {"What game are we playing?", new string[]{"Family \nFeud","Help! \nISIAKG"} },
        {"What is your reward?", new string[]{"A Million \nDollars","More \nMinigames!"} },
        {"How do you win?", new string[]{"You Don't","Survive \n10 Minigames"} },
        {"What is the capital of Australia?", new string[]{"Sydney","Canberra"} },
        {"What state am I from?", new string[]{"West \nVirginia","New \nJersey"} },
        {"What do you love about me?", new string[]{"Mustache","Hair"} },
        {"Why are you here?", new string[]{"To suffer.", "To get the \nrating up!" } },
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
        {"What is the meaning of life?", false}
        
    };

    private bool isRight = true;
    // Start is called before the first frame update

    void Start()
    {
        
        string q = "";
        LvlManager = LevelsManager.instance;

        if (LvlManager.levelNmbr < 4)
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
        { answerProcess(!isRight, false, false); } 
        else if (Input.GetKeyDown(KeyCode.D)) 
        { answerProcess(isRight, false, true); }

        if(timer>0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            answerProcess(false, true, false);
        }
    }

  

    void LBClicked()
    {
        answerProcess(!isRight, false, false);
    }

    void RBClicked()
    {
        answerProcess(isRight, false, true);
    }

    void answerProcess(bool condition, bool time, bool isRightBTN)
    {
        if(!finished)
        {
            finished = true;
            if (condition)
            {
                QTXT.text = "Correct!";
                Vector2 pos;
                if (isRightBTN)
                {
                    pos = new Vector2(BTNR.transform.position.x, BTNR.transform.position.y);
                }
                else
                {
                    pos = new Vector2(BTNL.transform.position.x, BTNL.transform.position.y);
                }
                Instantiate(QRight, pos, QRight.transform.rotation, transform);
                StartCoroutine(NxtLvl());

            }
            else if(time)
            {
                QTXT.text = "Too Slow!";
                MainGameUI.instance.TakeDamage();
                StartCoroutine(NxtLvl());
            }
            else
            {
                QTXT.text = "Nope. Death!";
                Vector2 pos;
                if (isRightBTN)
                {
                    pos = new Vector2(BTNR.transform.position.x, BTNR.transform.position.y );
                }
                else
                {
                    pos = new Vector2(BTNL.transform.position.x, BTNL.transform.position.y );
                }
                Instantiate(QWrong, pos, QWrong.transform.rotation, transform);
                MainGameUI.instance.TakeDamage();
                StartCoroutine(NxtLvl());
            }
        }
    }

    IEnumerator NxtLvl()
    {
        yield return new WaitForSeconds(2f);
        LvlManager.LevelComplete(true);
    }
}

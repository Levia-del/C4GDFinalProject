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
    private string[] mediumQs = {"What is the capital of Australia?", "What state is Steve Harvey from?", "What do you love about Steve Harvey?"};

    private string[] hardQs = {"Why are you here?", "Why.", "What is the meaning of life?", "What is a lexicon?","Error: question blocked", "Error: question blOcked"};

    private bool finished = false;
    private float timer = 5f;

    Dictionary<string, string[]> As = new Dictionary<string, string[]>()
    {
        {"Who is the best gameshow host?", new string[]{"Steve \nHarvey","IDK"} },
        {"What game are we playing?", new string[]{"Family \nFeud","Help! \nISIAKG"} },
        {"What is your reward?", new string[]{"A Million \nDollars!","More \nMinigames!"} },
        {"How do you win?", new string[]{"You Don't","Survive \n10 Minigames"} },
        {"What is the capital of Australia?", new string[]{"Sydney","Canberra"} },
        {"What state is Steve Harvey from?", new string[]{"West \nVirginia","New \nJersey"} },
        {"What do you love about Steve Harvey?", new string[]{"Mustache","Hair"} },
        {"Why are you here?", new string[]{"To suffer.", "To get the \nrating up!" } },
        {"Why.", new string[]{"...","...."} },
        {"What is the meaning of life?", new string[]{"To live","to Live"} },
        {"What is a lexicon?", new string[]{"Alphabet","An old \nbook"} },
        {"Error: question blocked", new string[]{"do not","report"} },
        {"Error: question blOcked", new string[]{"report","do not"} },
        {"What is the Capital of Australia?", new string[]{"Canberra", "Queensland"} },
        {"What is your greatest desire?", new string[]{"More \nMinigames","Freedom"} },
        {"What is the capital of New York State?", new string[]{"New York \nCity","Syracuse"} },
        {"What is your Reward?", new string[]{"More \nMinigames","A Million \nDollars!"} },
        {"Is this game gonna end?", new string[]{"Soon","Never will \n it"} }
    };

    Dictionary<string, bool> BoolAs = new Dictionary<string, bool>()
    {
        {"Who is the best gameshow host?", false },
        {"What game are we playing?", true},
        {"What is your reward?", true},
        {"How do you win?", false},
        {"What is the capital of Australia?", true},
        {"What state is Steve Harvey from?", false},
        {"What do you love about Steve Harvey?", false},
        {"Why are you here?", true},
        {"Why.", true},
        {"What is the meaning of life?", false},
        {"What is a lexicon?", false},
        {"Error: question blocked", true},
        {"Error: question blOcked", false},
        {"What is the Capital of Australia?", false},
        {"What is your greatest desire?", true},
        {"What is the capital of New York State?", true},
        {"What is your Reward?", false},
        {"Is this game gonna end?", true}        
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
                AudioManager.instance.PlaySFX(AudioManager.instance.QCorrect, .5f);
                QTXT.text = "Correct!";
                Vector2 pos;
                if (isRightBTN)
                {
                    pos = new Vector2(BTNR.transform.position.x, BTNR.transform.position.y+50);
                }
                else
                {
                    pos = new Vector2(BTNL.transform.position.x, BTNL.transform.position.y + 50);
                }
                Instantiate(QRight, pos, QRight.transform.rotation, transform);
                StartCoroutine(NxtLvl());

            }
            else if(time)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.QWrong, .5f);
                QTXT.text = "Too Slow!";
                MainGameUI.instance.TakeDamage();
                StartCoroutine(NxtLvl());
            }
            else
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.QWrong, .5f);
                QTXT.text = "Nope. Death!";
                Vector2 pos;
                if (isRightBTN)
                {
                    pos = new Vector2(BTNR.transform.position.x, BTNR.transform.position.y + 50);
                }
                else
                {
                    pos = new Vector2(BTNL.transform.position.x, BTNL.transform.position.y + 50);
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

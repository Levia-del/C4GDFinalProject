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

    private string[] easyQs = {"Who is the best gameshow host?"};
    private string[] mediumQs = { };
    private string[] hardQs = { };

    Dictionary<string, string[]> As = new Dictionary<string, string[]>()
    {
        {"Who is the best gameshow host?", new string[]{"Steve Harley","IDK"} }
    };

    Dictionary<string, bool> BoolAs = new Dictionary<string, bool>()
    {
        {"Who is the best gameshow host?", false }
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
            q = mediumQs[Random.Range(0, easyQs.Length)];
        }
        else
        {
            q = hardQs[Random.Range(0, easyQs.Length)];
        }

        QTXT.text = q;
        LTXT.text = As[q][0];
        RTXT.text = As[q][1];
        isRight = BoolAs[q];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

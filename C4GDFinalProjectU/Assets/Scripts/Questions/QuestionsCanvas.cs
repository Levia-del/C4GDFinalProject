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

    private string[] easyQs = { };
    private string[] mediumQs = { };
    private string[] hardQs = { };

    private bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonCanvas : MonoBehaviour
{
    public Button btn;
    public TMP_Text txt;

    private float waitTime;
    private bool isGo = false;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Wait";
        // Random wait duration between 3 and 15 seconds
        // (Unity's Random.Range uses an exclusive upper bound, so this
        //  lands in [3, 15) — effectively "between 3 and 15").
        waitTime = Random.Range(3f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            txt.text = "Go!";
            isGo = true;
        }
    }
}

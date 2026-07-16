using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DeathCanvas : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Restart);
        btn.transform.position = new Vector3(btn.transform.position.x, -650, 0);
        StartCoroutine(buttonApear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator buttonApear()
    {
        yield return new WaitForSeconds(1);
        btn.transform.DOMoveY(200, 2f);
    }
}

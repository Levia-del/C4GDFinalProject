using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("lol", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void lol()
    {
        SceneManager.LoadScene("Test 1");
    }
}

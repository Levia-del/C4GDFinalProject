using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] SnapToPoss;

    private int currInd = 1;
    // Start is called before the first frame update
    void Start()
    {
        Snap(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            subtrInd();
            Snap(currInd);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            addInd();
            Snap(currInd);
        }
    }

    void Snap(int index)
    {
        transform.position = new Vector2(SnapToPoss[index].transform.position.x, SnapToPoss[index].transform.position.y);
    }

    void addInd()
    {
        int ind = currInd+1;
        int l = SnapToPoss.Length-1;
        if (ind> l)
        {
            ind = l;
        }
        currInd = ind;
    }

    void subtrInd()
    {
        int ind = currInd - 1;
        if (ind <0)
        {
            ind = 0;
        }
        currInd = ind;
    }
}

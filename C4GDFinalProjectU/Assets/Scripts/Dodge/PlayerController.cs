using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        transform.DOMove(new Vector2(SnapToPoss[index].transform.position.x, SnapToPoss[index].transform.position.y), 0.2f);
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

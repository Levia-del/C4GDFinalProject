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
        transform.position = new Vector2(SnapToPoss[1].transform.position.x, SnapToPoss[1].transform.position.y);
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
        transform.DOScaleY(.5f, 0.1f);
        transform.DOMove(new Vector2(SnapToPoss[index].transform.position.x, SnapToPoss[index].transform.position.y), 0.08f);
        transform.DOScaleY(1f, .1f).WaitForCompletion();
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

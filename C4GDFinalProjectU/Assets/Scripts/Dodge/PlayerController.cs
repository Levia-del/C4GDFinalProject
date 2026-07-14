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

bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        if(isMoving)return;

        if(Input.GetKeyDown(KeyCode.A))
        {
            subtrInd();
            StartCoroutine(Snap(currInd));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            addInd();
            StartCoroutine(Snap(currInd));
        }
    }

    IEnumerator Snap(int index)
    {
        isMoving = true;
        transform.DOScaleY(.5f, .1f);
        yield return new WaitForSeconds(.1f);
        transform.DOMove(new Vector2(SnapToPoss[index].transform.position.x, SnapToPoss[index].transform.position.y), 0.08f);
        yield return new WaitForSeconds(.1f);
        transform.DOScaleY(1f, .1f);
        transform.DOPunchPosition(Vector3.up, .1f);
        yield return new WaitForSeconds(.1f);
        isMoving = false;
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

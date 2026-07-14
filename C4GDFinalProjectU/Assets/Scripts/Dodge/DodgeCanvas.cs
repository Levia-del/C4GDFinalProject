using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCanvas : MonoBehaviour
{
    public float timeToSurvive = 5f;
    public float spawnDelay = 1f;
    public GameObject projectile;
    public GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        int lvl = LevelsManager.instance.levelNmbr;
        if(lvl<3)
        {
            spawnDelay = 1f;
        }
        else if(lvl<6)
        {
            spawnDelay = 0.5f;
        }
        else
        {
            spawnDelay = 0.2f;
            timeToSurvive = 10f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(timeToSurvive>0)
        {
            timeToSurvive -= Time.deltaTime;
        }
        else
        {
            LevelFinish(true);
        }
    }

    public void LevelFinish(bool won)
    {
        
    }

    void spawnProjectile()
    {
        int i = Random.Range(0, spawnPoints.Length);
        Vector2 pos = new Vector2(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y);
        Instantiate(projectile, pos, projectile.transform.rotation);
    }
}

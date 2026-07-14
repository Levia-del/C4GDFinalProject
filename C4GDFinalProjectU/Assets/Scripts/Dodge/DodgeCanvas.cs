using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DodgeCanvas : MonoBehaviour
{
    
    public GameObject projectile;
    public GameObject[] spawnPoints;
    public TMP_Text FTXT;

    private float enemySpeed;
    private float timeToSurvive = 10f;
    private float spawnDelay = 1f;
    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        // int lvl = LevelsManager.instance.levelNmbr;
        int lvl = 10;
        if(lvl<3)
        {
            spawnDelay = 1.2f;
            enemySpeed = 10f;
        }
        else if(lvl<6)
        {
            spawnDelay = 0.7f;
            enemySpeed = 12f;
        }
        else
        {
            spawnDelay = 0.5f;
            timeToSurvive = 20f;
            enemySpeed = 14f;
        }
        InvokeRepeating("spawnProjectile", 0, spawnDelay);
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
        
        if (!finished)
        {
            finished = true;
            string q = "";
            if (won)
            {
                q = "You Survived!";
            }
            else
            {
                q = "Oh No. Deathhh!";
                MainGameUI.instance.health--;
            }
            FTXT.text = q;
            StartCoroutine(Wait());
        }
    }

    void spawnProjectile()
    {
        int i = Random.Range(0, spawnPoints.Length);
        Vector2 pos = new Vector2(spawnPoints[i].transform.position.x, spawnPoints[i].transform.position.y);
        GameObject g = Instantiate(projectile, pos, projectile.transform.rotation);
        g.GetComponent<Projectile>().speed = enemySpeed;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        LevelsManager.instance.LevelComplete(true);
    }
}

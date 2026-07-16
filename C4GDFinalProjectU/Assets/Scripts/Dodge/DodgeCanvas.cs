using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DodgeCanvas : MonoBehaviour
{
    
    public GameObject projectile;
    public GameObject[] spawnPoints;
    public TMP_Text FTXT;

    public GameObject player;
    public GameObject fallTarget;

    private float enemySpeed;
    private float timeToSurvive = 8f;
    private float spawnDelay = 1f;
    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        int lvl = LevelsManager.instance.levelNmbr;
        
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
        InvokeRepeating("spawnProjectile", 2, spawnDelay);
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
                AudioManager.instance.PlaySFX(AudioManager.instance.Cheer, .5f);
                AudioManager.instance.PlaySFX(AudioManager.instance.GeneralWin, 1f);
                q = "You Survived!";
            }
            else
            {
                player.GetComponent<PlayerController>().lose = true;
                player.transform.DOJump(fallTarget.transform.position, 5f, 1, .7f);
                q = "Oh No. Deathhh!";
                AudioManager.instance.PlaySFX(AudioManager.instance.GeneralLose, 2f);
                AudioManager.instance.PlaySFX(AudioManager.instance.crowdBoo, 1f);
                MainGameUI.instance.TakeDamage();
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

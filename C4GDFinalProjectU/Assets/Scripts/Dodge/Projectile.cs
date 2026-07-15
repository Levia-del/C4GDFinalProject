using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 50f;

    private DodgeCanvas dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = FindAnyObjectByType<DodgeCanvas>();
        AudioManager.instance.PlaySFX(AudioManager.instance.rockFall, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed, Space.World);
        transform.Rotate(0, 0, 500f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            dc.LevelFinish(false);
        }
    }

}

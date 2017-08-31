using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateBoss : MonoBehaviour {

    private GlobalScript global;
    private Life_points lf;

    public GameObject boss;
    public float Speed;
    private Vector2 pos;
    public float Delay;
    public GameObject generator;
    public GameObject BossPanel;

    public bool isActive = false;
    public bool isDead;

    public bool ActiveBattleBoss = false;

    private SimpleEnemy SimEn;

    private int Life_point;

    private Boss bs;

    private void Start()
    {
        pos = new Vector2(generator.transform.position.x, generator.transform.position.y);
        global = GameObject.Find("Global").GetComponent<GlobalScript>();
        InvokeRepeating("Spawn", 0, 1);

        lf = GameObject.Find("Global").GetComponent<Life_points>();

        
        
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("Boss"))
        {
            bs = GameObject.Find("Boss").GetComponent<Boss>();
            Life_point = bs.Life_point;
            isDead = bs.isDead;
        }
    }


    void Spawn()
    {
        if (global.kill_enemys % 2 == 0 && global.kill_enemys != 0 && !isActive)
        {

            GameObject Boss = Instantiate(boss, pos, Quaternion.identity) as GameObject;
            global.isGenerateEnemy = true;
            BossPanel.SetActive(true);
            isActive = true;
            ActiveBattleBoss = true;


        }
        else if (!ActiveBattleBoss && isDead)
        {
            isActive = false;
            global.isGenerateEnemy = false;
            BossPanel.SetActive(false);
            ActiveBattleBoss = false;
        }
        else if (Life_point <= 0)
        {
            isDead = true;
            ActiveBattleBoss = false;
            Life_point = 10;
        }
    }
}

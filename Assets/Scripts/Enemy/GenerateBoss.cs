using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateBoss : MonoBehaviour {

    private GlobalScript global;
    private Boss Boss;

    public GameObject boss;
    private Vector2 pos;

    public GameObject BossPanel;

    public bool isActive = false;
    private int CountBosses = 0;

    private void Start()
    {
        
        pos = new Vector2(transform.position.x, transform.position.y);

        global = GameObject.Find("Global").GetComponent<GlobalScript>();
    }

    private void Update()
    {
        if (global.kill_enemys % global.CallBoss == 0 && global.kill_enemys != 0  && !isActive)
        {
            
            GameObject b = Instantiate(boss, pos, Quaternion.identity) as GameObject;
            CountBosses++;
            isActive = true;
            BossPanel.SetActive(true);
            global.isGenerateEnemy = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour {

    private Boss boss;
    private GenerateBoss generate;

    public int kill_enemys = 0;
    public bool isGenerateEnemy = false;
    public bool isActive;
    public bool isActiveConsole = false;

    public bool BossDead = false;

    private void Start()
    {
        generate = GameObject.Find("GenerateBoss").GetComponent<GenerateBoss>();
    }

    public void BossIsDead(bool dead)
    {
        BossDead = true;
    }

    private void Update()
    {
        if (BossDead && isActive)
        {
            isGenerateEnemy = true;
            isActive = false;
            kill_enemys++;
            generate.BossPanel.SetActive(false);
        }
    }

    public void KillEnemy()
    {
        kill_enemys++;
        if (kill_enemys % 10 == 0 && kill_enemys != 0 && !isActive)
        {
            isGenerateEnemy = false;
            isActive = true;
        }
    }

}

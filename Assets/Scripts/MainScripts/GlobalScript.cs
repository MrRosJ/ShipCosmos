using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScript : MonoBehaviour {

    private Boss boss;
    private GenerateBoss generate;
    private ActivateConsole active;

    public int kill_enemys = 0;
    public bool isGenerateEnemy = false;
    public bool isActive = false;
    public bool isActiveConsole = false;
    public bool GlobalisActive = false;

    public int CallBoss;

    private void Start()
    {
        if(SceneManager.GetSceneByName("Game").ToString() == "Game")
            generate = GameObject.Find("GenerateBoss").GetComponent<GenerateBoss>();
        
    }

    private void Update()
    {
        

        if(GameObject.Find("Earth"))
            active = GameObject.Find("Earth").GetComponent<ActivateConsole>();
    }

    public void KillEnemy()
    {
        kill_enemys++;
    }

}

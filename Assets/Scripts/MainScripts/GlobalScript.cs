using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour {

    public int kill_enemys = 0;

    public bool isGenerateEnemy = false;

    public void KillEnemy()
    {
        kill_enemys++;
    }

}

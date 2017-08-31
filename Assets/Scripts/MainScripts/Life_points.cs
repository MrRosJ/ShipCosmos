using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_points : MonoBehaviour {

    private GlobalScript global;

    public int Life_points_boss;
    public int Life_points_enemy;


    private void Start()
    {
        global = GameObject.Find("Global").GetComponent<GlobalScript>();
    }
}

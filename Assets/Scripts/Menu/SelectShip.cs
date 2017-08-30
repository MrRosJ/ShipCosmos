using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SelectShip : MonoBehaviour {

    private int Ship_1_Active;
    private int Ship_2_Active;
    private int Ship_3_Active;

    public GameObject[] Buttn;

    public GameObject[] Selected;
    public GameObject[] Select;
    

    private void Start()
    {
        Ship_1_Active = PlayerPrefs.GetInt("ship_1", 0);
        Ship_2_Active = PlayerPrefs.GetInt("ship_2", 0);
        Ship_3_Active = PlayerPrefs.GetInt("ship_3", 0);
    }

    private void Update()
    {
        
    }

    public void Butt_Select_1()
    {

        Buttn[1].SetActive(false);
        Buttn[2].SetActive(false);
        Selected[0].SetActive(true);
        Select[0].SetActive(false);
    }

    public void Butt_Select_2()
    {
        
    }

    public void Butt_Select_3()
    {
        
    }
}

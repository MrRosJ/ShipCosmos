using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoughtShip : MonoBehaviour {

    public GameObject[] PriceShips;
    public GameObject[] Selected;
    public GameObject[] Select;

    private ShipControl ship;
    private int CurrentCoin;
    public GameObject Ship_Active_1;
    public GameObject Ship_Active_2;
    public GameObject Ship_Active_3;
    public GameObject ErrorMenu;
    private GameObject Price_1;
    private GameObject Price_2;
    private GameObject Price_3;

    private int Active_Ship_Pref_1;
    private int Active_Ship_Pref_2;
    private int Active_Ship_Pref_3;

    private bool Active_Ship_1;
    private bool Active_Ship_2;
    private bool Active_Ship_3;



    public GameObject[] SelectedT;

    void Start () {
        ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();

        CurrentCoin = PlayerPrefs.GetInt("coin", 0);
        Price_1 = GameObject.Find("Price_1");
        Price_2 = GameObject.Find("Price_2");
        Price_3 = GameObject.Find("Price_3");

        Active_Ship_Pref_1 = PlayerPrefs.GetInt("ship_1", 0);
        Active_Ship_Pref_2 = PlayerPrefs.GetInt("ship_2", 0);
        Active_Ship_Pref_3 = PlayerPrefs.GetInt("ship_3", 0);

        if (Active_Ship_Pref_1 == 1)
            Active_Ship_1 = true;

        if (Active_Ship_Pref_2 == 1)
            Active_Ship_2 = true;

        if (Active_Ship_Pref_3 == 1)
            Active_Ship_3 = true;


    }

    private void Update()
    {
        if (Active_Ship_Pref_1 == 1)
        {
            Ship_Active_1.SetActive(true);
            Price_1.SetActive(false);
        }

        if (Active_Ship_Pref_2 == 1)
        {
            Ship_Active_2.SetActive(true);
            Price_2.SetActive(false);
        }

        if (Active_Ship_Pref_3 == 1)
        {
            Ship_Active_3.SetActive(true);
            Price_3.SetActive(false);
        }
    }


    public void Buy_Ship_1()
    {
        if (CurrentCoin >= 200)
        {
            if (!Active_Ship_1)
            {
                Ship_Active_1.SetActive(true);
                Price_1.SetActive(false);
                CurrentCoin -= 200;
            }


            PlayerPrefs.SetInt("coin", CurrentCoin);
            PlayerPrefs.SetInt("ship_1", 1);
            Active_Ship_1 = true;



        }
        else
            ErrorMenu.SetActive(true);
    }

    public void Buy_Ship_2()
    {
        if (CurrentCoin >= 400)
        {
            if (!Active_Ship_2)
            {
                Ship_Active_2.SetActive(true);
                Price_2.SetActive(false);
                CurrentCoin -= 400;
            }


            PlayerPrefs.SetInt("coin", CurrentCoin);
            PlayerPrefs.SetInt("ship_2", 1);
            Active_Ship_2 = true;

        }
        else
            ErrorMenu.SetActive(true);
    }

    public void Buy_Ship_3()
    {
        if (CurrentCoin >= 600)
        {
            if (!Active_Ship_3)
            {
                Ship_Active_3.SetActive(true);
                Price_3.SetActive(false);
                CurrentCoin -= 600;
            }


            PlayerPrefs.SetInt("coin", CurrentCoin);
            PlayerPrefs.SetInt("ship_3", 1);
            Active_Ship_3 = true;

        }
        else
            ErrorMenu.SetActive(true);
    }

    public void ErrorContinue()
    {
        if (ErrorMenu)
            ErrorMenu.SetActive(false);
    }


    
}

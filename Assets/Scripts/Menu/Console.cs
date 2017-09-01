using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public string DebugCode;
    private MainMenu menu;
    private GlobalScript global;


    public int DebugCodeBool;
    public string input;


    private void Start()
    {
        menu = GameObject.Find("Canvas").GetComponent<MainMenu>();
        global = GameObject.Find("Global").GetComponent<GlobalScript>();
        DebugCodeBool = PlayerPrefs.GetInt("debugCode", 0);
    }

    private void Update()
    {
        if(GameObject.Find("Input"))
            input = GameObject.Find("Input").GetComponent<InputField>().text;        
    }

    public void SwitchCode()
    {
        PlayerPrefs.SetInt("debugCode", 1);
        switch (input)
        {
            case "1":
                menu.QuitPanel.SetActive(true);
                menu.input.SetActive(false);
                menu.On.SetActive(true);
                menu.Off.SetActive(false);
                break;
        }
    }
}

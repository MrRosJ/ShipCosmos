using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    public string DebugCode;
    private MainMenu menu;
    private GlobalScript global;
    public string input;


    private void Start()
    {
        menu = GameObject.Find("Canvas").GetComponent<MainMenu>();
        global = GameObject.Find("Global").GetComponent<GlobalScript>();
    }

    private void Update()
    {
        if(GameObject.Find("Input"))
            input = GameObject.Find("Input").GetComponent<InputField>().text;        
    }

    public void SwitchCode()
    {
        switch (input)
        {
            case "1":
                menu.DebugInfo.SetActive(true);
                menu.QuitPanel.SetActive(true);
                menu.input.SetActive(false);
                PlayerPrefs.SetInt("debugCode", 1);
                break;
        }
    }
    void Error()
    {

    }
}

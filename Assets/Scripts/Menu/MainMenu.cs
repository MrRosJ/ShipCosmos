using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private Console console;
    private ActivateConsole activeConsole;

    public Text CoinText;
    public Text ExperienceText;
    private int CountCoin;
    private int ExperienceCount;

    private GameObject StartM;
    private GameObject ExitM;
    private GameObject ShopM;

    public GameObject Back;
    public GameObject ShopPanel;
    public GameObject Console;
    public GameObject ConsolePanel;
    public GameObject QuitPanel;
    public GameObject input;
    public GameObject Button;
    public GameObject DebugInfo;

    private MoveCamera camera;

    public bool isActive = false;

    public string DebugCode;

    private void Start()
    {
        Time.timeScale = 1f;
        StartM = GameObject.Find("StartImage");
        ExitM = GameObject.Find("ExitImage");
        ShopM = GameObject.Find("ShopImage");
        activeConsole = GameObject.Find("Earth").GetComponent<ActivateConsole>();
        //camera = GameObject.Find("MainCamera").GetComponent<MoveCamera>();
    }

    private void Update()
    {
        CountCoin = PlayerPrefs.GetInt("coin");
        ExperienceCount = PlayerPrefs.GetInt("experience");
        CoinText.text = CountCoin.ToString();
        ExperienceText.text = ExperienceCount.ToString();
        if(PlayerPrefs.GetInt("debugCode", 0) == 1)
        {
            QuitPanel.SetActive(true);
            input.SetActive(false);
            ConsolePanel.SetActive(false);
        }

        if (activeConsole.isActiveConsole && !isActive )
        {
            Console.SetActive(true);
            isActive = true;
        }

        if(PlayerPrefs.GetInt("debugCode") == 1)
        {
            Console.SetActive(true);
            DebugInfo.SetActive(true);
        }

        if(GameObject.Find("Console"))
            console = GameObject.Find("Console").GetComponent<Console>();
    }

    public void StartGame()
    {

        SceneManager.LoadScene(1, LoadSceneMode.Single);
        return;
    }

    public void Shop()
    {

        
        StartM.SetActive(false);
        ExitM.SetActive(false);
        ShopM.SetActive(false);
        Back.SetActive(true);
        ShopPanel.SetActive(true);
        
    
        return;
    }

    public void ExitGame()
    {
        Application.Quit();
        return;
    }

    public void BackM()
    {
        StartM.SetActive(true);
        ExitM.SetActive(true);
        ShopM.SetActive(true);
        Back.SetActive(false);
        ShopPanel.SetActive(false);

        return;
    }

    public void EnterConsole()
    {
        ConsolePanel.SetActive(false);
        input.SetActive(true);
        GameObject.Find("Input").GetComponent<InputField>().text = "";
    }

    public void ButtonConsole()
    {
        console.SwitchCode();
    }

    public void QuitConsole()
    {
        ConsolePanel.SetActive(true);
        QuitPanel.SetActive(false);
        PlayerPrefs.SetInt("debugCode", 0);
        Console.SetActive(false);
        activeConsole.isActive = false;
        activeConsole.isActiveConsole = false;
        DebugInfo.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("debugCode", 0);
    }

    public void Settings()
    {
        //camera.AnimationSettings = true;
    }
}

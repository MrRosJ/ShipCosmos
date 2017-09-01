using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private Console console;

    public Text CoinText;
    public Text ExperienceText;
    private int CountCoin;
    private int ExperienceCount;

    private GameObject StartM;
    private GameObject ExitM;
    private GameObject ShopM;

    public GameObject Back;
    public GameObject ShopPanel;

    public GameObject Error;

    public GameObject ConsolePanel;
    public GameObject QuitPanel;
    public GameObject input;
    public GameObject On;
    public GameObject Off;
    public GameObject Button;
    public GameObject DebugInfo;
    public Camera camera;

    public Transform direction;

    public string DebugCode;

    private void Start()
    {
        Time.timeScale = 1f;
        StartM = GameObject.Find("StartImage");
        ExitM = GameObject.Find("ExitImage");
        ShopM = GameObject.Find("ShopImage");


        console = GameObject.Find("Console").GetComponent<Console>();
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
            On.SetActive(true);
            Off.SetActive(false);
            ConsolePanel.SetActive(false);
            DebugInfo.SetActive(true);
        }


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
        Error.SetActive(false);

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
        On.SetActive(false);
        Off.SetActive(true);
        QuitPanel.SetActive(false);
        PlayerPrefs.SetInt("debugCode", 0);
        DebugInfo.SetActive(false);
    }
}

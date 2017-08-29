using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

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

    private void Start()
    {
        Time.timeScale = 1f;
        StartM = GameObject.Find("StartImage");
        ExitM = GameObject.Find("ExitImage");
        ShopM = GameObject.Find("ShopImage");
           
    }

    private void Update()
    {
        CountCoin = PlayerPrefs.GetInt("coin");
        ExperienceCount = PlayerPrefs.GetInt("experience");
        CoinText.text = CountCoin.ToString();
        ExperienceText.text = ExperienceCount.ToString();
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
}

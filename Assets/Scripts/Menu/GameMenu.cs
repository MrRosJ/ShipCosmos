using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    private bool Pause = false;
    private bool sound = false;
    public GameObject PausePanel;
    public Color[] soundColors;
    public Image PauseImage;

    public GameObject PauseBtm1;
    public GameObject PauseBtm2;
    public GameObject LightPlay;

    public Sprite PauseP;
    public Sprite PlayP;

    public Image backgroundImage;
    private ShipControl ship;
    public Text SountT;

    private void Start()
    {
        Time.timeScale = 1f;
        ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
        
    }

    public void PauseM()
    {
        if (Pause)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
            Pause = false;
            PauseBtm1.SetActive(true);
            PauseBtm2.SetActive(true);
            LightPlay.SetActive(false);
            backgroundImage.sprite = PauseP; 
            return;
        }

        if (!Pause)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0.00001f;
            Pause = true;
            PauseBtm1.SetActive(false);
            PauseBtm2.SetActive(false);
            LightPlay.SetActive(true);
            backgroundImage.sprite = PlayP;
            return;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        return;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        
        return;
    }

    public void Sound()
    {
        if (sound)
        {
            AudioListener.volume = 0;
            sound = false;
            SountT.color = soundColors[1];
            return;
        }

        if (!sound)
        {
            AudioListener.volume = 1;
            sound = true;
            SountT.color = soundColors[0];
            return;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour {
    public int Life_points;
    public Image[] lifePoints;
    public Color lifeColor;
    
	public float speed;
    
    public GameObject bullet;
    public float shootDelay;
    public GameObject rocket;
    public int rocketCount;
    public Transform[] shootPoints;
    
    public bool isFire;
    public bool isReadyToShoot;
    
    public int BulletDamage;
    
    public SoundManager sm;

    public Image Point;

    public Sprite YellowPoint;
    public Sprite RedPoint;

    public Transform RocketTransform;

    private int ExperienceInPlayerPrefs;
    private int ExperienceToAddSession;

    public bool isDead = false;

    public GameObject GameOverM;
    public GameObject Ship;

    private GameObject JoyStick;
    private GameObject RocketBtm, LaserBrm;
    private GameObject InfoPanel;
    private GameObject ExpPanel;

    private int CoinInPlayerPrefs;
    private int CoinToAddSession;
    public Text coinsCountT;

    private int LevelInPlayerPrefs;
    public Text LevelT;
    private int SessionLevel;

    public Text AllExperience;

    void Start()
    {
        isReadyToShoot = true;
        isFire = false;

        CoinInPlayerPrefs = PlayerPrefs.GetInt("coin", 0);
        ExperienceInPlayerPrefs = PlayerPrefs.GetInt("experience", 0);
        LevelInPlayerPrefs = PlayerPrefs.GetInt("level", 1);

        int level = LevelInPlayerPrefs / 10;

        LevelT.text = (level++).ToString();

        JoyStick = GameObject.Find("Joystick");
        RocketBtm = GameObject.Find("Rocket");
        LaserBrm = GameObject.Find("Shoot");
        InfoPanel = GameObject.Find("Info");
        ExpPanel = GameObject.Find("Exp");
    }

	void Update(){
        coinsCountT.text = CoinToAddSession.ToString();
        LevelT.text = (SessionLevel + LevelInPlayerPrefs).ToString();
        AllExperience.text = ExperienceToAddSession.ToString();


        if(isFire && isReadyToShoot)
            Shoot();

        SwitchPoint();
        if (Life_points == 0 && !isDead)
            isDead = true;

        LevelUp(LevelInPlayerPrefs);

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x + 1;

        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x - 1;

        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y + 1.5f;

        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y - 1.5f;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder ), transform.position.z);

    }


    private void OnApplicationPause(bool pause)
    {
        if(pause || (isDead && Life_points == 0))
            AddCoinToPrefs();
    }

    public void Move(Vector2 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public void ChangeLife(){
        
        for  (int i=0; i < lifePoints.Length;i++)
        {
            if (!(i < Life_points))
                lifePoints[i].color = lifeColor;
        }
    }
    void Shoot()
    {
        if (isReadyToShoot) {
            foreach (Transform sp in shootPoints) {
                GameObject b = Instantiate(bullet, sp.position, Quaternion.identity) as GameObject;
                Destroy(b, 3);
                if (sp == shootPoints[shootPoints.Length - 1])
                    StartCoroutine(ShootDelay());
            }
        }

        sm.PlaySound(3);
    }

    public void RocketShoot()
    {
        if (rocketCount > 0)
        {
            GameObject r = Instantiate(rocket, RocketTransform.position, Quaternion.identity) as GameObject;
            rocketCount--;
            sm.PlaySound(2);
        }
    }

    IEnumerator ShootDelay()
    {
        isReadyToShoot = false;
        yield return new WaitForSeconds(shootDelay);
        isReadyToShoot = true;
    }

    public void Fire(bool fire)
    {
        isFire = fire;
    }

    public void Damage(int dmg)
    {
        Life_points -= dmg;
        if (Life_points <= 0)
        {
            Life_points = 0;
            isDead = true;
            GameOverMenu(isDead, Life_points);
            
        }

        ChangeLife();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("enemyBullet"))
        {
            Damage(1);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.CompareTag("coin"))
        {
            Destroy(coll.gameObject);
            AddCoin(3);
            sm.PlaySound(4);
        }

    }

    void SwitchPoint()
    {
        if (Life_points < 8 && Life_points > 2)
            Point.sprite = YellowPoint;
        else if (Life_points <= 2 && Life_points > 0)
            Point.sprite = RedPoint;
    }

    void GameOverMenu(bool isDeadl, int Life_pointsl)
    {
        if(Life_pointsl == 0 && isDeadl)
        {
            GameOverM.SetActive(true);
            LaserBrm.SetActive(false);
            JoyStick.SetActive(false);
            InfoPanel.SetActive(false);
            AddCoinToPrefs();
            AddExperience();
            return;
        }
    }

    void AddCoin(int coin)
    {
        CoinToAddSession += coin;
    }

    
    void AddCoinToPrefs()
    {
        CoinToAddSession += CoinInPlayerPrefs;
        PlayerPrefs.SetInt("coin", CoinToAddSession);
    }

    public void AddExp(int exp)
    {
        ExperienceToAddSession += exp;
    }

    void AddExperience()
    {
        ExperienceToAddSession += ExperienceInPlayerPrefs;
        PlayerPrefs.SetInt("experience", ExperienceToAddSession);
        
    }

    void LevelUp(int AllExperience)
    {
        if (AllExperience > 10)
        {
            SessionLevel++;
            ExperienceToAddSession = 0;
            ExperienceInPlayerPrefs = 0;
        }

    }
}

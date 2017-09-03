using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    private Life_points lf;
    private GlobalScript global;
    public GameObject bullet;
    public float delay;
    public Transform[] shootPoint;
    private ShipControl Ship;
    public bool isDead = false;
    private SoundManager sm;
    public int Life_point;
    public bool isActive = false;

    private GenerateBoss generate;
    private GenerateEnemy generateE;

    private Animation anim;

    public bool isMovingBoss = false;

    private Vector2 move;
    public float Speed;
    void Start()
    {
        lf = GameObject.Find("Global").GetComponent<Life_points>();

        Life_point = lf.Life_points_boss;
        InvokeRepeating("Shoot", 2, delay);

        Ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
        global = GameObject.Find("Global").GetComponent<GlobalScript>();

        if (gameObject == GameObject.FindWithTag("enemyBullet"))
        {
            if (gameObject.transform.position.x < -13)
                Destroy(gameObject);
        }
        generate = GameObject.Find("GenerateBoss").GetComponent<GenerateBoss>();
        generateE = GameObject.Find("GeneratorEnemy").GetComponent<GenerateEnemy>();
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        anim = GetComponent<Animation>();
        move = new Vector2(transform.position.x, Ship.transform.position.y);
    }

    void Update()
    {
        if (Life_point == 0 && !isDead)
            Boom();

        if (!anim.IsPlaying("BossAnimation") && !isMovingBoss)
            isMovingBoss = true;


        if (isMovingBoss)
            transform.position = Vector3.MoveTowards(transform.position, move, Speed * Time.deltaTime);
    }

    void Boom()
    {
        isDead = true;
        sm.PlaySound(0);
        Destroy(gameObject);
        Ship.AddExp(5);
        global.kill_enemys++;
        global.isActive = false;
        global.isGenerateEnemy = true;
        generate.BossPanel.SetActive(false);
        global.isGenerateEnemy = false;
        generateE.Repeat();
    }

    



    void Shoot()
    {
        for (int i = 0; i < shootPoint.Length; i++)
        {
            GameObject b = Instantiate(bullet, shootPoint[i].transform.position, Quaternion.identity) as GameObject;
        }
    }


    public void Damage(int dmg)
    {
        Life_point -= dmg;
        if (Life_point < 0)
            Life_point = 0;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("shipBullet"))
        {
            Damage(Ship.BulletDamage);
            Destroy(coll.gameObject);
            sm.PlaySound(1);
        }
    }
}

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

        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (Life_point == 0 && !isDead)
            Boom();

    }

    void Boom()
    {
        global.BossIsDead(true);
        isDead = true;
        sm.PlaySound(0);
        Destroy(gameObject);
        Ship.AddExp(5);
        global.KillEnemy();
        global.isActive = true;
        global.isGenerateEnemy = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    private  Life_points lf;
    public GameObject bullet;
    public float delay;

    public Transform[] shootPoint;

    private ShipControl Ship;
    private GlobalScript global;

    public bool isDead = false;

    private SoundManager sm;

    public GameObject Coin;

    private int Life_point;

    void Start()
    {
        lf = GameObject.Find("Global").GetComponent<Life_points>();

        Life_point = lf.Life_points_enemy;
        InvokeRepeating("Shoot", 2, delay);

        Ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
        global = GameObject.Find("Global").GetComponent<GlobalScript>();

        if(gameObject == GameObject.FindWithTag("enemyBullet"))
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
        isDead = true;
        sm.PlaySound(0);
        Destroy(gameObject);
        SpawnCoin();
        Ship.AddExp(5);
        global.KillEnemy();
    }

    void SpawnCoin()
    {
        GameObject c = Instantiate(Coin, transform.position, Quaternion.identity) as GameObject;
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

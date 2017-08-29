using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    public int Life_points;
    public GameObject bullet;
    public float delay;

    public Transform shootPoint;

    private ShipControl Ship;

    public bool isDead = false;

    private SoundManager sm;

    public GameObject Coin;

    void Start()
    {
        InvokeRepeating("Shoot", 2, delay);

        Ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();

        if(gameObject == GameObject.FindWithTag("enemyBullet"))
        {
            if (gameObject.transform.position.x < -13)
                Destroy(gameObject);
        }

        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    void Update()   
    {
        if (Life_points == 0 && !isDead)
            Boom();
    }

    void Boom()
    {
        isDead = true;
        sm.PlaySound(0);
        Destroy(gameObject);
        SpawnCoin();
        Ship.AddExp(5);
    }

    void SpawnCoin()
    {
        GameObject c = Instantiate(Coin, transform.position, Quaternion.identity) as GameObject;
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet, shootPoint.position, Quaternion.identity) as GameObject;
    }


    public void Damage(int dmg)
    {
        Life_points -= dmg;
        if (Life_points < 0)
            Life_points = 0;
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

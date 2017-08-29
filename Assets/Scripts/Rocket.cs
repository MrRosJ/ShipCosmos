using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    private SoundManager sm;
    private ShipControl ship;
    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("enemy"))
        {
            coll.gameObject.GetComponent<SimpleEnemy>().Damage(10);
            Destroy(gameObject);
            sm.PlaySound(0);
        }

        if (coll.gameObject.CompareTag("enemyBullet"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            sm.PlaySound(0);
        }
    }
}

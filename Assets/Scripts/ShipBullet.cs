using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour {

    public SoundManager sm;

    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("enemyBullet"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            sm.PlaySound(1);
        }
    }
}

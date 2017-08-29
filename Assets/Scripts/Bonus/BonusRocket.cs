using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRocket : MonoBehaviour {

    public ShipControl Ship;
    public SoundManager sm;

    private void Start()
    {
        Ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("ship")) {
            Destroy(gameObject);
            if (Ship.Life_points < 9)
                Ship.Life_points += 2;
            else
                Ship.Life_points = 10;
            sm.PlaySound(4);
            Ship.AddExp(1);
        }
    }
}

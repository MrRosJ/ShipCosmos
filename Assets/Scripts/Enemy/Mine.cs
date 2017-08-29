using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    private GameObject ship;
    public float disToActive;
    public float Speed;

    private SoundManager sm;

	void Start () {
        ship = GameObject.Find("ShipPlayer");
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
	}
	
	void Update () {
		if(Vector2.Distance(transform.position, ship.transform.position) < disToActive)
            transform.position = Vector2.MoveTowards(transform.position, ship.transform.position, Time.deltaTime * Speed);

        if (Vector2.Distance(transform.position, ship.transform.position) <= 0.5f)
        {
            ship.GetComponent<ShipControl>().Damage(3);
            sm.PlaySound(0);
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("shipBullet"))
        {
            ship.GetComponent<ShipControl>().AddExp(3);
            Destroy(gameObject);
            Destroy(coll.gameObject);
            sm.PlaySound(0);
        }

        if (coll.gameObject.CompareTag("rocket"))
        {
            ship.GetComponent<ShipControl>().AddExp(5);
            Destroy(gameObject);
            Destroy(coll.gameObject);
            sm.PlaySound(0);
        }
    }
}

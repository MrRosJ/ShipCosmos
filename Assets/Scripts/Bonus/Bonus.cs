using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    public GameObject[] bonuses;

    public int lifePoints;
    public bool isDead = false;
    private ShipControl ship;

    private SoundManager sm;

    private void Start()
    {
        sm = GameObject.Find("PlayZone").GetComponent<SoundManager>();
        ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
    }

    private void Update()
    {
        if (lifePoints == 0 && !isDead)
            Boom();
    }

    void Boom()
    {
        ship.AddExp(4);
        isDead = true;
        GameObject bonus = bonuses[Random.Range(0, bonuses.Length)];
        GameObject b = Instantiate(bonus, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
        sm.PlaySound(0);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("shipBullet"))
        {
            lifePoints--;
            Destroy(coll.gameObject);
            sm.PlaySound(1);
        }

        if (coll.gameObject.CompareTag("rocket"))
        {
            Boom();
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}

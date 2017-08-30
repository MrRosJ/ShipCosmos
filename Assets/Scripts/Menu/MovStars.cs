using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovStars : MonoBehaviour {

    public float Speed;

    public Vector2 dir;

    private GameObject ship;

    private void Start()
    {
        ship = GameObject.Find("ShipPlayer");
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * Speed);
        if (transform.position.x < ship.transform.position.x - 12)
            Destroy(gameObject);
    }
}

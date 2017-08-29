using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStars : MonoBehaviour {

    public float Speed;
    private GameObject Ship;

    public Vector2 dir;

    private void Start()
    {
        Ship = GameObject.Find("ShipPlayer");
    }

    void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * Speed, Space.World);
        if (transform.position.x < Ship.transform.position.x - 10)
            Destroy(gameObject);

    }
}

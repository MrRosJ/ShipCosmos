﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovStars : MonoBehaviour {

    public float Speed;

    public Vector2 dir;

    private GameObject gm;


    private void Start()
    {
        gm = GameObject.Find("Destroy");
    }

    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * Speed);
        if (transform.position.x < gm.transform.position.x - 12)
            Destroy(gameObject);
    }
}

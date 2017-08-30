using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenStars : MonoBehaviour {

    public GameObject[] stars;
    public float delay;

    public float minY;
    public float maxY;

    public float Speed;
    
    private void Start()
    {
        InvokeRepeating("Spawn", 0, delay);
    }

    void Spawn()
    {
        GameObject gm = stars[Random.Range(0, stars.Length)];

        Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));

        GameObject s = Instantiate(gm, pos, Quaternion.identity) as GameObject;

        s.GetComponent<MovStars>().Speed = Speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public float MaxSpeed;
    public float MinSpeed;
    public Vector2 dir;

    public GameObject fx;

    private bool isQuit;

    private ShipControl ship;

    public float speed;

    private void Start()
    {
        ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
    }
    void Update () {

        speed = Random.Range(MinSpeed,MaxSpeed);
        gameObject.transform.Translate(speed * dir * Time.deltaTime);
        if (gameObject.transform.position.x < ship.transform.position.x - 25)
            Destroy(gameObject);
    }

    private void OnApplicationQuit()
    {
        isQuit = true;
    }

    void OnDestroy()
    {
        if (!isQuit && Time.timeScale == 1 && !ship.isDead)
        {
            GameObject f = Instantiate(fx, transform.position, Quaternion.identity) as GameObject;
            f.GetComponent<ParticleSystem>().Play();
            Destroy(f, f.GetComponent<ParticleSystem>().main.duration);
        }
    }

    
}

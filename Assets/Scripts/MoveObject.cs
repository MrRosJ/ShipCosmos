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
    private GameObject destroy;
    private void Start()
    {
        ship = GameObject.Find("ShipPlayer").GetComponent<ShipControl>();
        destroy = GameObject.Find("Destroy");
    }
    void Update () {

        speed = Random.Range(MinSpeed,MaxSpeed);
        gameObject.transform.Translate(speed * dir * Time.deltaTime);
        if (gameObject.transform.position.x < destroy.transform.position.x - 10)
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

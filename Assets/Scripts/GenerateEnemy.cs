using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    private GlobalScript global;

    public GameObject[] Enemys;
    public float minDelay;
    public float maxDelay;

    public GameObject bonus;

    public float minY, maxY;

    void Start()
    {
        global = GameObject.Find("Global").GetComponent<GlobalScript>();
        StartCoroutine(Spawn());
    }


    void Repeat()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (!global.isGenerateEnemy)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            Vector2 pos = new Vector2(transform.position.x, Random.Range(minY, maxY));
            GameObject e = Instantiate(Enemys[Random.Range(0, Enemys.Length)], pos, Quaternion.identity) as GameObject;
            int r = Random.Range(0, 100);
            Vector2 BonusPos = new Vector2(transform.position.x, Random.Range(minY, maxY));

            if (r <= 30)
            {
                GameObject q = Instantiate(bonus, BonusPos, Quaternion.identity) as GameObject;
            }
            Repeat();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public GameObject sfx;
    public AudioClip[] audioclips;


	public void PlaySound(int soundNum)
    {
        GameObject s = Instantiate(sfx, Vector2.zero, Quaternion.identity) as GameObject;
        AudioSource AS = s.GetComponent<AudioSource>();

        AS.clip = audioclips[soundNum];
        AS.Play();
        Destroy(s, audioclips[soundNum].length);
    }
}

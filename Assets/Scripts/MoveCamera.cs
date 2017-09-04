using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    
    public Animation anim;


    private void Start()
    {
        anim = GameObject.Find("Main Camera").GetComponent<Animation>();
    }

    void Update () {

		
	}
}

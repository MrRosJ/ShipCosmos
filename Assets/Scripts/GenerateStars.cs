using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStars : MonoBehaviour {

    public GameObject[] stars;

	public float MinimumScale;
	public float MaximumScale;

	public float MinimumY;
	public float MaximumY;

	public float delay;

    public Vector2 dir;

	void Start () {
		InvokeRepeating ("Spawn", 0, delay * 0.1f);
	}
	
	void Spawn () {
		GameObject star = stars [Random.Range (0, stars.Length)];


		Vector2 pos = new Vector2 (transform.position.x, Random.Range (MinimumY, MaximumY));

		float scl = Random.Range (MinimumScale, MaximumScale);

		Vector3 scale = new Vector3 (scl,scl,scl);
		GameObject s = Instantiate (star, pos, Quaternion.identity);


        
		s.transform.localScale = scale;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidGenerator : MonoBehaviour {
//	public int numAsteroids, maxXVelocity, maxYVelocity;
	public Vector3[] AsteroidVelo;
	public float minSize, maxSize;
	public GameObject[] possibleAsteroids;
	// Use this for initialization

	void Start () {
       	///* 
		System.Random rand = new System.Random();
		for(int i = 0; i < AsteroidVelo.Length; i++){
            //Random number to select asteroid
			int r = (int)rand.Next(0,possibleAsteroids.Length);
			//instantiate
			Debug.Log(r);
			GameObject o = (GameObject)Instantiate(possibleAsteroids[r]);
			//randomly scale x any y evenly
			double size = rand.NextDouble()*(maxSize-minSize) + minSize;
			
			o.transform.position = new Vector3(transform.position.x + AsteroidVelo[i].x,transform.position.y + AsteroidVelo[i].y,transform.position.z);

			o.transform.localScale = new Vector3((float)size,(float)size,0);
			AsteroidVelo[i].z = 0;
			o.GetComponent<Rigidbody2D>().velocity = AsteroidVelo[i];
			
		}
		//*/
		
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}
}
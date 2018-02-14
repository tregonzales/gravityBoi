using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidGenerator : MonoBehaviour {
	public int numAsteroids, maxXVelocity, maxYVelocity;
	public float minSize, maxSize;
	public GameObject[] asteroids;
	// Use this for initialization
	void Start () {
        System.Random rand = new System.Random();
		for(int i = 0; i < numAsteroids; i++){
            //Random number to select asteroid
			int r = (int)rand.Next(0,asteroids.Length);
			//instantiate
			GameObject o = (GameObject)Instantiate(asteroids[r]);
			//randomly scale x any y evenly
			double size = rand.NextDouble()*(maxSize-minSize) + minSize;
			o.transform.position = transform.position;
			o.transform.localScale = new Vector3((float)size,(float)size,0);
			//add random velocity
			double xVelo = rand.NextDouble() * maxXVelocity * 2 - maxXVelocity;
			double yVelo = rand.NextDouble() * maxYVelocity * 2 - maxYVelocity;
			o.GetComponent<Rigidbody2D>().velocity = new Vector3((float)xVelo,(float)yVelo,0);

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}
}
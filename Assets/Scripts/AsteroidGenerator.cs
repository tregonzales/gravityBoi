using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {
	public int numAsteroids, maxXVelocity, maxYVelocity;
	public float minSize, maxSize;
	public GameObject[] asteroids;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < numAsteroids; i++){
			//Random number to select asteroid
			//instantiate
			//randomly scale x any y evenly
			//add random velocity
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}
}
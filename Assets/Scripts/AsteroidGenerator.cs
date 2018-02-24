using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidGenerator : MonoBehaviour {
	public Vector3[] AsteroidVelo; //holds asteroid start velocities
	public float minSize, maxSize; //holds max and min scale of asteroid
	public GameObject[] possibleAsteroids; //holds possible asteroids

	void Start () {
		for(int i = 0; i < AsteroidVelo.Length; i++){ //goes through all asteroids that are gonna be created
			int r = (int)UnityEngine.Random.Range(0.0f,(float)possibleAsteroids.Length); //gets random asteroid to use
			GameObject o = (GameObject)Instantiate(possibleAsteroids[r]);//instantiates the asteroid
			double size = (double)UnityEngine.Random.Range(0.0f,1.0f)*(maxSize-minSize) + minSize; //get a random scale size within limits
			o.transform.position = new Vector3(transform.position.x + AsteroidVelo[i].x,transform.position.y + AsteroidVelo[i].y,transform.position.z); //set start position of asteroid so they don't collide
			o.transform.localScale = new Vector3((float)size,(float)size,0); //scale the asteroid
			AsteroidVelo[i].z = 0; //make sure z is set to zero since 2D
			o.GetComponent<Rigidbody2D>().velocity = AsteroidVelo[i]; //give the asteroid its initial velocity
		}
	}
}
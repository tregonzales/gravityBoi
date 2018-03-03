using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidGenerator : MonoBehaviour {
	public Vector3[] AsteroidVelo; //hold asteroid initial velocity
	public float minSize, maxSize; //scale limits
	public GameObject[] possibleAsteroids; //possible prefabs

	void Start () {
		for(int i = 0; i < AsteroidVelo.Length; i++){
            //Random number to select asteroid
			int r = (int)UnityEngine.Random.Range(0.0f,(float)possibleAsteroids.Length);
			//instantiate
			GameObject o = (GameObject)Instantiate(possibleAsteroids[r]);
			//random number to scale x any y evenly
			double size = (double)UnityEngine.Random.Range(0.0f,1.0f)*(maxSize-minSize) + minSize;
			//give position where it doesn't collide with others
			o.transform.position = new Vector3(transform.position.x + AsteroidVelo[i].x,transform.position.y + AsteroidVelo[i].y,transform.position.z);
			//scale asteroid
			o.transform.localScale = new Vector3((float)size,(float)size,0);
			AsteroidVelo[i].z = 0;
			//give the asteroid its initial velocity
			o.GetComponent<Rigidbody2D>().velocity = AsteroidVelo[i];
		}
	}
}
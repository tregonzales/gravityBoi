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
		//UnityEngine.Random rand = new UnityEngine.Random();
		for(int i = 0; i < AsteroidVelo.Length; i++){
			//Debug.Log(Time.time);
            //Random number to select asteroid
			int r = (int)UnityEngine.Random.Range(0.0f,(float)possibleAsteroids.Length);
			//instantiate
			GameObject o = (GameObject)Instantiate(possibleAsteroids[r]);
			//randomly scale x any y evenly
			double size = (double)UnityEngine.Random.Range(0.0f,1.0f)*(maxSize-minSize) + minSize;
			
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
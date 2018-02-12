﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D boi;
	public float gravBoostSpeed;
	public float antiGravBoostSpeed;
	public float gravScale;
	public float numBoosts;
	private float curSpeed;
	// Use this for initialization
	void Start () {
		boi = GetComponent<Rigidbody2D>();
		curSpeed = antiGravBoostSpeed;
	}
	
	
	// Update is called once per frame
	void Update () {

		//toggle gravity and change the speed of boost depending on current gravity 
		 if (Input.GetKeyDown(KeyCode.Space)){
			 if(boi.gravityScale == 0) {
				 boi.gravityScale =gravScale;
				 curSpeed = gravBoostSpeed;
			 }
			 else {
            	boi.gravityScale = 0;
				curSpeed = antiGravBoostSpeed;
			 }
		 }

		//get the mouse position and use as directional vector to boost
		Vector2 origin = transform.position;
		Vector2 boost = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = (boost - origin).normalized;
		OrientRobot(direction);
		
		//use the boost with left click, also reduce how many boosts the character has this level
		if (Input.GetMouseButtonDown(0)) {
			if (numBoosts != 0) {
				boi.velocity += curSpeed*direction;
				numBoosts--;
			}
		}
	}

	void OrientRobot(Vector2 direction){

		if (direction.x == 0 && direction.y == 0) {
			//ugly but less code than two or statements bc im lazy rn tbh
		}
		else {
			float angle = Mathf.Atan2(direction.y, direction.x);
			angle = angle - Mathf.PI * 0.5f;
			angle = angle * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
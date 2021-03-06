﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Rigidbody2D boi;
	public float gravBoostSpeed;
	public float antiGravBoostSpeed;
	public float gravScale;
	public int numBoosts;
	private float curSpeed;
	public Sprite broke;
	public AudioClip asteroidDeath;
	private AudioSource laserDeath;
	SpriteRenderer spriteRenderer;
	boostCountController boostCounter;
	boostController boostController;
	private gravityIndicator gravityIndicator;
    private bool isDead = false;

    private bool startUpdate;
	
	// Use this for initialization
	void Start () {
		boostCounter = GameObject.FindObjectOfType<boostCountController>();
		boostController = this.gameObject.transform.GetChild(0).GetComponent<boostController>();
		gravityIndicator = GameObject.FindObjectOfType<gravityIndicator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		laserDeath = GetComponent<AudioSource>();
		boi = GetComponent<Rigidbody2D>();
		curSpeed = antiGravBoostSpeed;
	}
	
		void Update () {

		//make sure the player is in a moveable state
		if (!GameManager.instance.paused && startUpdate && isDead == false) {
			//toggle gravity and change the speed of boost depending on current gravity 
			if (Input.GetKeyDown(KeyCode.Space)){
				if(boi.gravityScale == 0) {
					boi.gravityScale = gravScale;
					curSpeed = gravBoostSpeed;
				}
				else {
					boi.gravityScale = 0;
					curSpeed = antiGravBoostSpeed;
				}
				gravityIndicator.updateGravity(boi.gravityScale);
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
					boostCounter.updateCounter(numBoosts);
					boostController.playBoost();
				}
			}
		}
	}

	//rotation of the character
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

	//laser death animation
	public void dieLaser() {
        isDead = true;
		spriteRenderer.sprite = broke;
		laserDeath.Play();
		boi.gravityScale = 1;
		GameManager.instance.RestartTheGameAfterSeconds(2f);
	}


	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.CompareTag("Asteroid")){
            isDead = true;
			//if the player hits an asteroid
			spriteRenderer.sprite = broke;
			laserDeath.PlayOneShot(asteroidDeath,1.0f);
			boi.gravityScale = 1;
			GameManager.instance.RestartTheGameAfterSeconds(2f);
		}
    }

    public void startUpdating()
    {
        startUpdate = true;
    }

}

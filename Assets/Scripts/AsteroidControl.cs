using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour {
	public AudioClip clip;
	public AudioSource sound;

	public void destroyAsteroidByLaser(){ //called if an asteroid hits a laser
		sound.Play(); //plays sound of destruction
		transform.position = Vector3.up * 999f; //moves object off screen
		Destroy(this.gameObject,clip.length); //destroys game object after the sound is done playing
	}

}

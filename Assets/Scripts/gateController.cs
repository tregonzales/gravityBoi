using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour {

	private AudioSource gateSound;
	private bool played;
	public bool bonusLevel;
	// Use this for initialization
	void Start () {
		played = false;
		gateSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		//see if the character is alive and then pass to next level
		if (other.gameObject.CompareTag("Player") && other.GetComponent<SpriteRenderer>().sprite.name == "character") {
			if (!played) {
				gateSound.Play();
				played = true;
			}
			//if its the bonus level then you go back to the end screen
			if (bonusLevel) {
				GameManager.instance.LoadSceneByIndex(19);
			}
			else {
				GameManager.instance.LoadNextScene(.5f);
			}
		}
	}
}

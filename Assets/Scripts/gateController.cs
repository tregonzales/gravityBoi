using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour {

	private AudioSource gateSound;
	private bool played;
	// Use this for initialization
	void Start () {
		played = false;
		gateSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Player") && other.GetComponent<SpriteRenderer>().sprite.name == "character") {
			if (!played) {
				gateSound.Play();
				played = true;
			}
			GameManager.instance.LoadNextScene(.5f);
		}
	}
}

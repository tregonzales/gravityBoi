using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControl : MonoBehaviour {

	public Sprite explosion;
	public AudioClip clip;
	public AudioSource sound;

	public void destroyAsteroidByLaser(){
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		//spriteRenderer.sprite = explosion;
		sound.Play();
		transform.position = Vector3.up * 999f;
		Destroy(this.gameObject,clip.length);

	}

}

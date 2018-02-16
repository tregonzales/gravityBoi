using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityIndicator : MonoBehaviour {


	public Sprite[] frames;
	private SpriteRenderer spriteRenderer;
	private float toggle;

	// Use this for initialization
	void Start () {
		spriteRenderer = transform.GetComponent<SpriteRenderer>();
		toggle = GameObject.Find("GravityBoi").GetComponent<Rigidbody2D>().gravityScale;
		updateGravity(toggle);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateGravity(float toggle) {
		spriteRenderer.sprite = toggle == 0 ? frames[0] : frames[1];
	}
}

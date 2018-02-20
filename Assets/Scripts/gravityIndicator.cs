using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gravityIndicator : MonoBehaviour {


	public Sprite[] frames;
	private Image img;
	private float toggle;

	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
		toggle = GameObject.Find("GravityBoi").GetComponent<Rigidbody2D>().gravityScale;
		updateGravity(toggle);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateGravity(float toggle) {
		img.sprite = toggle == 0 ? frames[0] : frames[1];
	}
}

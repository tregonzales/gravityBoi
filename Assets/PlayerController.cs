using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D boi;
	public float boostSpeed;
	public float antiGravSpeed;
	public float gravScale;
	public float numBoosts;
	private float curSpeed;
	// Use this for initialization
	void Start () {
		boi = GetComponent<Rigidbody2D>();
		curSpeed = antiGravSpeed;
	}
	
	
	// Update is called once per frame
	void Update () {

		 if (Input.GetKeyDown(KeyCode.Space)){
			 if(boi.gravityScale == 0) {
				 boi.gravityScale =gravScale;
				 curSpeed = boostSpeed;
			 }
			 else {
            	boi.gravityScale = 0;
				curSpeed = antiGravSpeed;
			 }
		 }

		Vector2 origin = transform.position;
		Vector2 boost = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 direction = (boost - origin).normalized;
		
		if (Input.GetMouseButtonDown(0)) {
			if (numBoosts != 0) {
				boi.velocity = curSpeed*direction;
				numBoosts--;
			}
		}
        
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostCountController : MonoBehaviour {


	public Sprite[] frames;
	private SpriteRenderer onesPlace;
	private SpriteRenderer tensPlace;
	private int boosts;

	// Use this for initialization
	void Start () {
		boosts = GameObject.Find("GravityBoi").GetComponent<PlayerController>().numBoosts;
		onesPlace = transform.GetChild(0).GetComponent<SpriteRenderer>();
		tensPlace = transform.GetChild(1).GetComponent<SpriteRenderer>();
		updateCounter(boosts);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateCounter(int numBoosts) {
		onesPlace.sprite = frames[numBoosts % 10];
		tensPlace.sprite = frames[numBoosts / 10];
	}
}

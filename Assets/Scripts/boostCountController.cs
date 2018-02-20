using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boostCountController : MonoBehaviour {


	public Sprite[] frames;
	private Image onesPlace;
	private Image tensPlace;
	private int boosts;

	// Use this for initialization
	void Start () {
		boosts = GameObject.Find("GravityBoi").GetComponent<PlayerController>().numBoosts;
		onesPlace = transform.GetChild(0).GetComponent<Image>();
		tensPlace = transform.GetChild(1).GetComponent<Image>();
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

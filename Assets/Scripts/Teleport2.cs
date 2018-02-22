using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour {

    public GameObject targetGate;
    public GameObject boi;
    public string targetOrientation;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        boi.transform.position = new Vector2(targetGate.transform.position.x, targetGate.transform.position.y);

        if (targetOrientation == "up")
        {
            boi.GetComponent<Rigidbody2D>().velocity = Vector2.up * boi.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        else if (targetOrientation == "down")
        {
            boi.GetComponent<Rigidbody2D>().velocity = Vector2.down * boi.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        else if (targetOrientation == "right")
        {
            boi.GetComponent<Rigidbody2D>().velocity = Vector2.right * boi.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        else if (targetOrientation == "left")
        {
            boi.GetComponent<Rigidbody2D>().velocity = Vector2.left * boi.GetComponent<Rigidbody2D>().velocity.magnitude;
        }

        GetComponent<AudioSource>().Play();
    }
}

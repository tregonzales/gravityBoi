using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {


    public GameObject redGate1;
    public GameObject redGate2;
    public GameObject yellowGate1;
    public GameObject yellowGate2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("red1"))
        {
            transform.position = new Vector2(redGate2.transform.position.x - .25f, redGate2.transform.position.y);
        }
        else if (other.CompareTag("red2"))
        {
            transform.position = new Vector2(redGate1.transform.position.x + .25f, redGate1.transform.position.y);
        }

        if (other.CompareTag("yellow1"))
        {
            transform.position = new Vector2(yellowGate2.transform.position.x - .25f, yellowGate2.transform.position.y);
        }
        else if (other.CompareTag("yellow2"))
        {
            transform.position = new Vector2(yellowGate1.transform.position.x + .25f, yellowGate1.transform.position.y);
        }


    }
}

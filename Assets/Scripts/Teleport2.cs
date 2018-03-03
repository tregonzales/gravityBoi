using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour {

    // Gate to teleport to
    public GameObject targetGate;   

    // Player
    public GameObject boi;

    // Which way the target gate is facing for getting correct directional change
    public string targetOrientation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if player has collided with gate
        if(!other.gameObject.tag.Equals("Player")){
            return;
        }

        // Set player's position to the target gate's position
        boi.transform.position = new Vector2(targetGate.transform.position.x, targetGate.transform.position.y);

        // Set velocity of the player in the correct direction with the same magnitude
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

        // Teleport Sound
        GetComponent<AudioSource>().Play();
    }
}

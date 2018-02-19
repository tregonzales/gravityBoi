using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public Sprite[] frames;

    public float framesPerSecond = 5;

    public float degreesPerSecond;

    SpriteRenderer spriteRenderer;

	public AudioClip laserSound;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        int currentFrameIndex = 0;
        while (true) {
            spriteRenderer.sprite = frames [currentFrameIndex % 2];
            yield return new WaitForSeconds(.05f); // this halts the functions execution for x seconds. Can only be used in coroutines.
            if (laserSound != null) {
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
        	}
			currentFrameIndex++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (degreesPerSecond != 0) {
            transform.Rotate(0, 0, degreesPerSecond*Time.deltaTime);
        }
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
        GameManager.instance.RestartTheGameAfterSeconds(0.5f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public Sprite[]frames;

    public float framesPerSecond = 5;

    SpriteRenderer spriteRenderer;

	public AudioClip explosionSound;

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
            yield return new WaitForSeconds(.02f); // this halts the functions execution for x seconds. Can only be used in coroutines.
            currentFrameIndex++;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (explosionSound != null) {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
	}
}

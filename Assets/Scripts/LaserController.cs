using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public Sprite[] frames;

    public float framesPerSecond = 5;

    public float degreesPerSecond;
    public float moveXSpeed;
    public float moveYSpeed;
    public float leftXLimit;
    public float rightXLimit;
    public float upperYLimit;
    public float lowerYLimit;

    SpriteRenderer spriteRenderer;

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
			currentFrameIndex++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (degreesPerSecond != 0) {
            transform.Rotate(0, 0, degreesPerSecond*Time.deltaTime);
        }
        Move();
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("Player")){
            other.gameObject.GetComponent<PlayerController>().dieLaser();
        }
    }

    void Move(){
        if(moveXSpeed == 0 && moveYSpeed == 0){
            return;
        }
        transform.position += new Vector3(moveXSpeed*Time.deltaTime,moveYSpeed*Time.deltaTime,0);
        if(moveXSpeed != 0){
            if(transform.position.x <= leftXLimit)
                moveXSpeed = moveXSpeed * -1;
            if(transform.position.x >= rightXLimit)
               moveXSpeed = moveXSpeed * -1;
        }
        if(moveYSpeed != 0){
            if(transform.position.y <= lowerYLimit)
                moveYSpeed = moveYSpeed * -1;
            if(transform.position.y >= upperYLimit)
                moveYSpeed = moveYSpeed * -1;
        }
    }
}

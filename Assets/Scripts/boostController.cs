using UnityEngine;
using System.Collections;

public class boostController : MonoBehaviour
{

    public Sprite[] frames;
    public float framesPerSecond;
    public AudioSource boostSound;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	public void playBoost() {
        GetComponent<AudioSource>().Play();
            
		StartCoroutine(PlayAnimation());
	}

    IEnumerator PlayAnimation()
    {
        int currentFrameIndex = 0;
        while (currentFrameIndex < frames.Length) {
            spriteRenderer.sprite = frames [currentFrameIndex];
            yield return new WaitForSeconds(1f / framesPerSecond); // this halts the functions execution for x seconds. Can only be used in coroutines.
            currentFrameIndex++;
        }
        spriteRenderer.sprite = null;
    }
}

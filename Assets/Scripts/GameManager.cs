using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake(){
		instance = this;
	}

	public void RestartTheGameAfterSeconds(float seconds){
		StartCoroutine (LoadSceneAfterSeconds (seconds, SceneManager.GetActiveScene ().name));
	}

	public void LoadScene(float seconds, string sceneName){
		StartCoroutine (LoadSceneAfterSeconds (seconds, sceneName));
	}

	public void LoadNextScene(float seconds) {
		StartCoroutine (LoadSceneAfterSeconds (seconds, null));
	}

	IEnumerator LoadSceneAfterSeconds(float seconds, string sceneName){
		yield return new WaitForSeconds (seconds);
		if (sceneName == null) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
		else {
			SceneManager.LoadScene (sceneName);
		}
		
	}
}


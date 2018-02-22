using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameObject pauseMenu;
	public bool paused;
	public bool mainMenu;

	void Awake(){
		instance = this;
		//create the pause menu interaction and start it inactive
		if (!mainMenu) {
			pauseMenu = GameObject.Find("pauseMenu");
			paused = false;
			Time.timeScale = 1.0f;
			pauseMenu.SetActive(paused);
		}
	}

	public void RestartTheGameAfterSeconds(float seconds){
		Time.timeScale = 1.0f;
		StartCoroutine (LoadSceneAfterSeconds (seconds, SceneManager.GetActiveScene ().name));
	}

	public void LoadScene(float seconds, string sceneName){
		StartCoroutine (LoadSceneAfterSeconds (seconds, sceneName));
	}

	public void LoadSceneByIndex(int i){
		SceneManager.LoadScene(i);
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene("MainMenu");
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

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape) && !mainMenu) {
			TogglePauseMenu();
		}
		
		if (Input.GetKeyDown(KeyCode.R) && !mainMenu) {
        	RestartTheGameAfterSeconds(0.5f);
    	}
	}

	public void TogglePauseMenu() {
		if (paused)
        {
            pauseMenu.SetActive(!paused);
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseMenu.SetActive(!paused);
            Time.timeScale = 0f;
        }
        paused = !paused;
    }
}


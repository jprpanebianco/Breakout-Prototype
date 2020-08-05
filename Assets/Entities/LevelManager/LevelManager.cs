using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
		SceneManager.LoadScene(name);
		BrickController.breakableCount = 0;
	}
	
	public void QuitRequest(){
		Debug.Log ("I want to quit!");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
        int indexSC = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexSC+ 1);
        Debug.Log("LoadNextLevel attempted)");
	}
	
	public void BrickDestroyed() {
		if (BrickController.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Ball")
        {
            levelManager.LoadLevel(SceneManager.GetActiveScene().name);
        }
        else if (collider.tag == "Collectible")
        {
            Destroy(collider.gameObject);
        }
		else if (collider.tag == "Zombie")
        {
            collider.gameObject.SetActive(false);
        }
	}	
}

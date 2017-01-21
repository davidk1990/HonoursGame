using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashAutoLoad : MonoBehaviour {

	public float loadTime;
	public string sceneName;

	// Use this for initialization
	void Start () {
		//Change the integer value to determine the length of time to wait before starting the game
		Invoke("LoadScene", loadTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LoadScene(){
		SceneManager.LoadScene(sceneName);
	}
}

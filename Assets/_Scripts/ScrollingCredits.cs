using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ScrollingCredits : MonoBehaviour {

	public GameObject creditText;


	private float speed = 75f;
	private int loadNextLevelTime = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		creditText.transform.Translate(Vector3.up * Time.deltaTime * speed);
		StartCoroutine(BackToMM());

		if(Input.anyKey){
			LoadMainMenu();
		}  
	}

	public IEnumerator BackToMM(){
		yield return new WaitForSeconds(loadNextLevelTime);

		LoadMainMenu();
	}

	public void LoadMainMenu(){
		SceneManager.LoadScene(1);
	}	
}

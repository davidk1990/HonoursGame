using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour {

	public Image fadePanel;
	public GameObject trigger;

	private Color panelColor = Color.black;
	private bool ending = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ending){
			panelColor.a += 0.000001f;
			fadePanel.color = panelColor;
			StartCoroutine(LoadNextLevel());
		}
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			
			Debug.Log("Should start credits now");
			ending = true;
			Debug.Log(ending);
			trigger.GetComponent<BoxCollider>().isTrigger = false;
		}
	}

	public IEnumerator LoadNextLevel(){
		yield return new WaitForSeconds(2);
		//TODO Change this when all scenes are in
		SceneManager.LoadScene(6);
	}
}

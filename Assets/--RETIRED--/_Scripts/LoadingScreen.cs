using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	AsyncOperation ao;

	public GameObject loadingScreenBG;
	public Slider progBar;
	public Text loadingText;

	public AudioSource mmMusic;




	// Use this for initialization
	void Start () {
		loadingScreenBG.SetActive(false);
		progBar.gameObject.SetActive(false);
		loadingText.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel01(){
		loadingScreenBG.SetActive(true);
		progBar.gameObject.SetActive(true);
		loadingText.gameObject.SetActive(true);
		//mmMusic.Stop();

		loadingText.text = "Loading...";

		StartCoroutine(LoadLevelWithRealProgress());
		

	}

	IEnumerator LoadLevelWithRealProgress(){
		
		yield return new WaitForSeconds(1);

		ao = SceneManager.LoadSceneAsync(2);
		progBar.value = ao.progress;

		yield return null;

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class SnowyIntroSequence : MonoBehaviour {

	//Reference to the fpscharactercontroller
	public GameObject playerObject;

	//Overlay Panel
	public Image overlay;

	//Time to fade panel over
	public float fadeTime;

	//Opening sequence time
	public float lengthOfOpening = 45f;

	//Game time running
	public float gameTime;

	public AudioSource storyAudio;

	public AudioClip gunshot;

	public AudioClip story01;

	private Color overlayColor = Color.black;

	void Awake(){
		
		StartCoroutine(OverlayFadeToClear());
		StartCoroutine(PlayGunshotNoise());
		StartCoroutine(OverlayFadeToblack());
		//TODO Get better voice acting
		//StartCoroutine(PlayStory01());
		StartCoroutine(LoadNextLevel());

	}

	// Use this for initialization
	void Start () {
		playerObject.GetComponent<FirstPersonController>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator OverlayFadeToClear(){
		overlay.gameObject.SetActive(true);
		overlay.color = overlayColor;

		yield return new WaitForSeconds(5);

		while (overlay.color.a > 0){
			overlayColor.a -= 0.002f;
			overlay.color = overlayColor;
			yield return null;
		}

		overlay.gameObject.SetActive(false);
		playerObject.GetComponent<FirstPersonController>().enabled = true;

	}

	private IEnumerator PlayGunshotNoise(){
		yield return new WaitForSeconds(30);
		storyAudio.PlayOneShot(gunshot);
	}
	private IEnumerator PlayStory01(){
		yield return new WaitForSeconds(35);
		storyAudio.PlayOneShot(story01);
	}

	private IEnumerator OverlayFadeToblack(){
		yield return new WaitForSeconds(30);
		overlay.gameObject.SetActive(true);
		playerObject.GetComponent<FirstPersonController>().enabled = false;
		float deathTime = 2.0f;

		Vector3 deathPosition = new Vector3(transform.position.x, 0.05f, transform.position.z);
		Quaternion deathRotation = new Quaternion(transform.rotation.x, transform.rotation.y, -90.0f, 180.0f);

		playerObject.GetComponent<Transform>().position = Vector3.Lerp(transform.position, deathPosition, deathTime * Time.deltaTime);
		playerObject.GetComponent<Transform>().rotation = Quaternion.Lerp(transform.rotation, deathRotation, deathTime * Time.deltaTime);


		overlay.color = overlayColor;



		while (overlay.color.a < 255){
			overlayColor.a += 0.002f;
			overlay.color = overlayColor;
			yield return null;
		}

	}

	private IEnumerator LoadNextLevel(){
		yield return new WaitForSeconds(45);
		//TODO Change this when all scenes are in
		SceneManager.LoadScene(4);
	}
}

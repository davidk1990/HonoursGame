using UnityEngine;
using System.Collections;
using UnityStandardAssets;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class StartSequence : MonoBehaviour {

	//References to the image effects on the player camera
	public MotionBlur MB;
	public Twirl TW;

	//Reference to the fpscharactercontroller
	public GameObject playerObject;

	//Current time the game has been running
	private float gameTime;
	//How long the opening sequence should be
	private float openingEnd = 10.5f;
	//Is the opening sequence still happening
	private bool stillOpening = true;


	//Stuff for the fadeInPanel
	public Image fadePanel;
	private float fadeTime;
	private Color panelColor = Color.black;

	//Reference to the playerHud
	public GameObject playerHUD;

	public Objectives objective;


	// Use this for initialization
	void Start () {
		playerHUD.SetActive(true);
		objective.enabled = false;
		playerObject.GetComponent<FirstPersonController>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Increments time as long as game time doesn't equal the time for the intro
		if(gameTime < openingEnd){
			gameTime += Time.deltaTime;
			MB.blurAmount -= 0.001f;
			TW.radius.x -= 0.008f;
			TW.radius.y -= 0.008f;
			panelColor.a -= 0.004f;
			fadePanel.color = panelColor;
			playerObject.GetComponent<FirstPersonController>().enabled = false;
		}


		if(gameTime >= openingEnd  && stillOpening == true){
			objective.enabled = true;
			MB.blurAmount = 0f;
			MB.enabled = false;
			TW.enabled = false;
			fadePanel.enabled = false;
			stillOpening = false;
			playerObject.GetComponent<FirstPersonController>().enabled = true;

			objective.ShowObjective();
		}
	}
}

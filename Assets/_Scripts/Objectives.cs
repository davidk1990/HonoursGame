using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Objectives : MonoBehaviour {

	public Text objectiveText;
	public int objectiveCounter = 0;
	public string[] objectives = {
	" ",
	"<->Find out what's happening",
	"<->Follow the wiring to backup generator",
	"<->Return to computer terminal",
	"<->Find keycard for exit",
	"<->Escape through exit"
	};

	// Use this for initialization
	void Start () {
		UpdateObjective();
	}
	
	// Update is called once per frame
	void Update () {
		if(CrossPlatformInputManager.GetButtonDown("Objective")){
				ShowObjective();
			}
	}

	public void ShowObjective(){
		objectiveText.enabled = true;

		StartCoroutine(HideObjective());
	}

	IEnumerator HideObjective(){
		yield return new WaitForSeconds(5);


		objectiveText.enabled = false;
	}

	public void UpdateObjective(){
		
		objectiveCounter++;
		Debug.Log("Objective updated, now on objective: " + objectiveCounter);
		objectiveText.text = objectives[objectiveCounter];
		ShowObjective();

	}
}

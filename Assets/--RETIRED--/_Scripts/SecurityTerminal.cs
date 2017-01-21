using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class SecurityTerminal : MonoBehaviour {

	public GameObject computerCanvas;

	public GameObject playerObject;

	public GameObject cameraFeeds;

	// Use this for initialization
	void Start () {
		computerCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowComputerUI(){
		playerObject.GetComponent<FirstPersonController>().enabled = false;

		//Unlocks the mouse cursor so you can click
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
		computerCanvas.SetActive(true);
	}

	public void HideComputerUI(){
		computerCanvas.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		playerObject.GetComponent<FirstPersonController>().enabled = true;
	}

	public void ShowCameraFeed(){
		cameraFeeds.SetActive(true);
	}

	public void HideCameraFeed(){
		cameraFeeds.SetActive(false);
	}
}

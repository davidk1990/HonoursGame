using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class SecurityTerminal : MonoBehaviour {

	public GameObject computerCanvas;

	public GameObject playerObject;

	public GameObject cameraFeeds;

	public GameObject backgroundImg;

	public GameObject emails;

	public GameObject exitScreen;

	public GameObject logInBtn;
	public GameObject logInBtn2;
	public GameObject emailBtn;
	public GameObject cameraBtn;
	public GameObject openExitBtn;
	public GameObject lowPowerText;

	//Stuff for dealing with having the key to unlock the door
	public bool hasKey = false;
	public GameObject exitDoor;

	//Exit screen message options
	public GameObject noKeyMessage;
	public GameObject keyMessage;

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
		emails.SetActive(false);
		exitScreen.SetActive(false);
	}

	public void HideCameraFeed(){
		cameraFeeds.SetActive(false);
	}

	public void ShowEmails(){
		emails.SetActive(true);
		cameraFeeds.SetActive(false);
		exitScreen.SetActive(false);
	}

	public void HideEmails(){
		emails.SetActive(false);
	}

	public void ShowExitScreen(){
		exitScreen.SetActive(true);
		cameraFeeds.SetActive(false);
		emails.SetActive(false);

		if(hasKey){
			keyMessage.SetActive(true);
			noKeyMessage.SetActive(false);
			exitDoor.GetComponent<Door>().locked = false;
			exitDoor.GetComponent<Door>().ChangeDoorState();

		}else{
			keyMessage.SetActive(false);
			noKeyMessage.SetActive(true);
		}
	}

	public void HideExitScreen(){
		exitScreen.SetActive(false);
	}

	public void ShowMainCompScreen(){
		logInBtn2.SetActive(false);
		emailBtn.SetActive(true);
		cameraBtn.SetActive(true);
		openExitBtn.SetActive(true);
	}

	public void LowPower(){
		backgroundImg.GetComponent<Image>().color = Color.black;
		logInBtn.SetActive(false);
		lowPowerText.SetActive(true);
	}

	public void PowerOn(){
		backgroundImg.GetComponent<Image>().color = Color.white;
		lowPowerText.SetActive(false);
		logInBtn2.SetActive(true);

	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class Note : MonoBehaviour {

	//Sprite image of the note being read to be displayed on the screen
	public Image noteImage;
	public GameObject readingNotePanel;
	public GameObject noteText;

	//Write what you want displayed in this
	public string newspaperText;

	//public GameObject hideNoteButton;

	//Audio for different note interactions
	public AudioClip pickUpSound;
	public AudioClip putAwaySound;

	public GameObject playerObject;

	public string name;

	public GameObject newsUIText;

	//Is the note a key?
	public bool isKey = false;

	//What does it unlock if it is?
	public GameObject unlockable;

	bool readNote = false;
	int currentRead;

	// Use this for initialization
	void Start () {
		noteImage.enabled = false;


	}

	void Update(){
		if(CrossPlatformInputManager.GetButtonDown("Fire2")){
			HideNoteImage();
		}

	}

	public void ShowNoteImage(){
		if(readNote == false){
			UpdateBackstoryCount();
		}	

		noteImage.enabled = true;
		readingNotePanel.SetActive(true);
		noteText.GetComponent<Text>().text = newspaperText;
		noteText.SetActive(true);
		GetComponent<AudioSource>().PlayOneShot(pickUpSound);
		playerObject.GetComponent<Flashlight>().enabled = false;
		readNote = true;

		//hideNoteButton.SetActive(true);

		//Makes it so the player can't move when reading the note
		playerObject.GetComponent<FirstPersonController>().enabled = false;

		//Unlocks the mouse cursor so you can click away note
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(isKey){
        	unlockable.GetComponent<Door>().locked = false;
			unlockable.GetComponent<Door>().ChangeDoorState();
        }
	}

	public void HideNoteImage(){
		noteImage.enabled = false;
		readingNotePanel.SetActive(false);
		noteText.SetActive(false);
		//hideNoteButton.SetActive(false);
		GetComponent<AudioSource>().PlayOneShot(putAwaySound);
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		playerObject.GetComponent<FirstPersonController>().enabled = true;
		playerObject.GetComponent<Flashlight>().enabled = true;
		this.enabled = false;
	}

	public void UpdateBackstoryCount(){
		newsUIText.GetComponent<Text>().text = name + " out of 4 newspapers read";
		newsUIText.SetActive(true);

		StartCoroutine(HideBackstory());
	}

	public IEnumerator HideBackstory(){
		yield return new WaitForSeconds(2);

		newsUIText.SetActive(false);
	}
}

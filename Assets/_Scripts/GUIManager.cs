using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class GUIManager : MonoBehaviour {

	//Reference to the in-game pause panel
	public GameObject pausePanel;

	//Reference to the playerHUD
	public GameObject playerHUD;

	//reference to the eventsystem
	private EventSystem eventSystem;

	//A reference to the first button selected on the Main Menu
	private GameObject storedSelected;

	//Reference to the player object
	private GameObject player;


	//bool to determine if paused or not
	private bool isPaused = false;


	// Use this for initialization
	void Start () {
		eventSystem = GetComponent<EventSystem>();

		//Look in the event system heirarchy to find out what this object is
		storedSelected = eventSystem.firstSelectedGameObject;

		player = GameObject.FindGameObjectWithTag("Player");



	}
	
	// Update is called once per frame
	void Update () {
		//If statement to check if the storedSelected is empty
		if(eventSystem.currentSelectedGameObject != storedSelected){

			//If nothing is selected
			if(eventSystem.currentSelectedGameObject == null){
				//Set the selected object to the stored object
				eventSystem.SetSelectedGameObject(storedSelected);
			}else{
				storedSelected = eventSystem.currentSelectedGameObject;
			}
		}

		//If you press the pause button - controller start or keyboard esc
		if(CrossPlatformInputManager.GetButtonDown("Cancel")){
			Pause();
		} 
	}

	public void Play(){
		SceneManager.LoadSceneAsync(3);
	}

	public void Quit(){
		Application.Quit();
	}

	public void Options(){
		SceneManager.LoadSceneAsync(2);
	}

	public void Pause(){
		isPaused = !isPaused;
		//Debug.Log("Game paused =" +isPaused);

		if(isPaused){
			pausePanel.SetActive(true);
			playerHUD.SetActive(false);
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<FirstPersonController>().enabled = false;
		}else{
			pausePanel.SetActive(false);
			playerHUD.SetActive(true);
			Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
			Time.timeScale = 1;
			player.GetComponent<FirstPersonController>().enabled = true;
		}
	}


	public void QuitToMainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadSceneAsync(1);
	}
}

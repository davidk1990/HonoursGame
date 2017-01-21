using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

	//Stores the gameobject that the raycast is hitting currently
	public GameObject selectedGameobject;

	public Image interactionIcon;

	public LayerMask interactLayer;

	//Distance you can interact with objects
	private float interactDistance = 3f;

	//Not currently being used
	private bool isInteracting = false;

	//Highlight color, muck around with this
	public Color highlightColor = new Color(0f,1f,0f, 1f);

	private GameObject player;





	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		if(interactionIcon != null){
			interactionIcon.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//drawing raycast for testing purposes, delete before final build
		DebugRayCastDraw();

		//Draws a ray in front of player
		Ray ray = new Ray(transform.position, transform.forward);
		//Results stored in hit
		RaycastHit hit;

		//If the spherecast hits something 
		//The float value is the thickness of the sphere and allows for easier interacting
		if(Physics.SphereCast(ray,0.5f, out hit, interactDistance, interactLayer)){
			interactionIcon.enabled = true;
			
			//If interaction button is pressed
			if(CrossPlatformInputManager.GetButtonDown("ControllerInteract")){	
				
				//If the thing you hit has a door tag
				if(hit.collider.CompareTag("Door")){
					hit.collider.GetComponent<Door>().doorAjar = false;
					hit.collider.transform.GetComponent<Door>().ChangeDoorState();

				//If the thing you hite has a note tag
				}else if(hit.collider.CompareTag("Note")){
					hit.collider.GetComponent<Note>().ShowNoteImage();
					isInteracting = true;
				//If the thing you hit is pickupable
				}else if(hit.collider.gameObject.GetComponent<Pickupable>()){
					if(player.GetComponent<PickUpObject>().carrying == false){
						player.GetComponent<PickUpObject>().objectToCarry = hit.collider.gameObject;
						player.GetComponent<PickUpObject>().Pickup();
					//If already carrying something, then drop it
					}else if(player.GetComponent<PickUpObject>().carrying == true){
						player.GetComponent<PickUpObject>().DropObject();
					}
				//Interacting with the computer
				}else if(hit.collider.CompareTag("Computer")){
					hit.collider.GetComponent<SecurityTerminal>().ShowComputerUI();
				//Initial pickup of the flahlight in the game
				}else if(hit.collider.CompareTag("Flashlight")){
					player.GetComponent<Flashlight>().hasFlashlight = true;
					player.GetComponent<Flashlight>().DeleteFlashlight();

				}

			}
			//Fix the highlighting script -- too many errors
//
//			if(hit.collider.CompareTag("Interactable") || hit.collider.CompareTag("Door")){
//				selectedGameobject = hit.collider.gameObject;
//
//			}else{
//				selectedGameobject.GetComponent<Renderer>().material.color = Color.clear;
//				selectedGameobject = null;
//			}
//		//If ray is currently not hitting something
//		}else if(selectedGameobject){
//			selectedGameobject.GetComponent<Renderer>().material.color = Color.clear;
//			selectedGameobject = null;
//		}
//
//
//		if(selectedGameobject != null){
//			selectedGameobject.GetComponent<Renderer>().material.color = highlightColor;
		}else{
			interactionIcon.enabled = false;
			isInteracting = false;
		}

		//If looking at an interactable then display interact icon
		if(isInteracting){
			interactionIcon.enabled = false;
		}else{
			//interactionIcon.enabled = true;
		}

	}



	//Method to draw a debug raycast to test interactions
	void DebugRayCastDraw(){
		RaycastHit hit;
		float theDistance;

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;

		Debug.DrawRay(transform.position, forward, Color.green);

		if(Physics.Raycast(transform.position, (forward), out hit)){
			theDistance = hit.distance;
			//Debug.Log(theDistance + " " + hit.collider.gameObject.name);
			//isInteracting = true;

		}else{
			//isInteracting = false;
		}

		//Attempt at highlighting interactions
		//if(isInteracting){
			//hit.collider.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
		//}else{
			//hit.collider.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
		//}
	}
}

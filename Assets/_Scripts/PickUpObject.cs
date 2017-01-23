using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PickUpObject : MonoBehaviour {

	//Object being to carry
	public GameObject objectToCarry;

	//reference to fps camera
	GameObject mainCamera;

	//bool to determine whether we're already carrying an object
	public bool carrying = false;

	//Distance to hold from face
	float distance = 2f;

	//Smoothing for carrying an object
	float smooth = 4f;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

		if(carrying){
			Carry(objectToCarry);

		}

	}

	//Function to carry an object
	public void Carry(GameObject carriable){

			//Pickup the object and hold it a distance from face
			carriable.GetComponent<Rigidbody>().useGravity = false;
			carriable.transform.position = Vector3.Lerp(carriable.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		
	}

	//Function that picks an object up
	public void Pickup(){

		carrying = true;
	
	}



	//Drop the object
	public void DropObject(){

		objectToCarry.GetComponent<Rigidbody>().useGravity = true;
		objectToCarry = null;
		carrying = false;

	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class ComputerKey : MonoBehaviour {

	//Is the computer button a key
	public bool isKey = false;

	//What does it unlock if it is?
	public GameObject unlockable;

	// Use this for initialization
	void Start () {

	}

	void Update(){


	}

	public void OpenDoor(){
        if(isKey){
        	unlockable.GetComponent<Door>().locked = false;
			unlockable.GetComponent<Door>().ChangeDoorState();
        }
	}

}

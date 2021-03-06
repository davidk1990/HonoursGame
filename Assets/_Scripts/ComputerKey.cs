﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class ComputerKey : MonoBehaviour {

	//Is the computer button a key
	public bool isKey = false;

	//What does it unlock if it is?
	public GameObject unlockable;

	public GameObject securityTerminal;

	public GameObject keycardText;

	// Use this for initialization
	void Start () {

	}

	void Update(){
	
	}

	public void ObtainedKey(){
		securityTerminal.GetComponent<SecurityTerminal>().hasKey = true;
		keycardText.SetActive(true);
		StartCoroutine(RemoveText());


	}

	public void OpenDoor(){
        if(isKey){
        	unlockable.GetComponent<Door>().locked = false;
			
        }
	}

	public IEnumerator RemoveText(){
		yield return new WaitForSeconds(2);


		keycardText.SetActive(false);

		Destroy(this.gameObject);
	}

}

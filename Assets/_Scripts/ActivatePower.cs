﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class ActivatePower : MonoBehaviour {
	//Current value of the meter
	public float currentValue;

	//Value that the meter will start at
	public float startValue = 50.0f;

	//Value for meter to be empty 
	public float emptyValue = 0.0f;

	//Value for the meter to be full
	public float fullValue = 100.0f;

	//Empty rate
	public float emptyRate = 5f;

	//Fill rate
	public float fillRate = 1.0f;

	//Area of lights to turn on
	public Light[] lights;

	//Reference to electric bolts prefab attached to player
	public GameObject electroBolt;
	public GameObject[] flares;
	public GameObject[] doors;

	//Reference to the fpscharactercontroller
	public GameObject playerObject;

	public GameObject computerTerminal;



	// Use this for initialization
	void Start () {
		currentValue = startValue;

	}
	
	// Update is called once per frame
	void Update () {
		if(currentValue > emptyValue){
			currentValue -= emptyRate * Time.deltaTime;

		}

		if(currentValue <= emptyValue){
			Debug.Log("You died");
		}else if(currentValue >= fullValue){
			FinishTapping();
		}

		if(CrossPlatformInputManager.GetButtonDown("ControllerInteract")){
			//Debug.Log("Pressing interact button");
			currentValue += fillRate;
		}

	}

	public void StartUpSequence(){
		
		electroBolt.SetActive(true);
		foreach(GameObject flare in flares){
			flare.SetActive(true);
		}
		playerObject.GetComponent<FirstPersonController>().enabled = false;
		this.GetComponent<AudioSource>().Play();
	}

	void TurnOnLights(){
		foreach(Light light in lights){
			light.gameObject.SetActive(true);
		}
	}

	void FinishTapping(){
		electroBolt.SetActive(false);
		foreach(GameObject flare in flares){
			flare.SetActive(false);
		}

		foreach(GameObject door in doors){
			door.GetComponent<Door>().open = true;
		}
		playerObject.GetComponent<FirstPersonController>().enabled = true;
		TurnOnLights();

		//disable the activatePower script
		this.GetComponent<ActivatePower>().enabled = false;
		this.GetComponent<AudioSource>().Stop();
		computerTerminal.GetComponent<SecurityTerminal>().PowerOn();	
	}
}
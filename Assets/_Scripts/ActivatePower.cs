using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets;
using UnityStandardAssets.ImageEffects;
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
	public float fillRate = 2f;

	//Area of lights to turn on
	public Light[] lights;

	//Reference to electric bolts prefab attached to player
	public GameObject electroBolt;
	public GameObject[] flares;
	public GameObject[] doors;

	//Reference to the fpscharactercontroller
	public GameObject playerObject;

	public MotionBlur MB;
	public bool motionTrue = false;

	public GameObject computerTerminal;
	public Objectives objectives;
	public GameObject tapText;

	public GameObject scareTrigger;


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
			FailedStartup();
		}else if(currentValue >= fullValue){
			FinishTapping();
		}

		if(CrossPlatformInputManager.GetButtonDown("ControllerInteract")){
			//Debug.Log("Pressing interact button");
			currentValue += fillRate;
		}

		if(motionTrue == true){
			MB.blurAmount += 0.1f;
		}

	}

	public void StartUpSequence(){
		
		electroBolt.SetActive(true);
		tapText.SetActive(true);
		foreach(GameObject flare in flares){
			flare.SetActive(true);
		}
		MB.enabled = true;
		motionTrue = true;
		playerObject.GetComponent<FirstPersonController>().enabled = false;
		this.GetComponent<AudioSource>().Play();
	}

	public void FailedStartup(){
		electroBolt.SetActive(false);
		tapText.SetActive(false);
		foreach(GameObject flare in flares){
			flare.SetActive(false);
		}
		MB.enabled = false;
		motionTrue = false;
		playerObject.GetComponent<FirstPersonController>().enabled = true;
		this.GetComponent<AudioSource>().Stop();
	}

	void TurnOnLights(){
		foreach(Light light in lights){
			light.gameObject.SetActive(true);
		}
	}

	void FinishTapping(){
		electroBolt.SetActive(false);
		scareTrigger.SetActive(true);
		tapText.SetActive(false);
		foreach(GameObject flare in flares){
			flare.SetActive(false);
		}

		foreach(GameObject door in doors){
			door.GetComponent<Door>().locked = false;
		}
		playerObject.GetComponent<FirstPersonController>().enabled = true;
		TurnOnLights();
		MB.enabled = false;
		motionTrue = false;

		//disable the activatePower script
		this.GetComponent<ActivatePower>().enabled = false;
		this.GetComponent<AudioSource>().Stop();
		computerTerminal.GetComponent<SecurityTerminal>().PowerOn();
		objectives.UpdateObjective();	
		this.gameObject.layer = LayerMask.NameToLayer("Default");
	}
}

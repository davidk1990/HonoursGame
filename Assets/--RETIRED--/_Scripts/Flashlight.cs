using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Flashlight : MonoBehaviour {

	public bool hasFlashlight = false;
	public bool flashLightOn;

	//Gameobject for the flashlight in the scene before pickup
	public GameObject flashLight;

	//Arms attached to the player with the flashlight
	public GameObject arms;

	//Actual flashlight light
	public Light flashlightSource;

	//Audio for turning on and off the flashlight
	public AudioClip flashLightOnSFX;
	public AudioClip flashLightOffSFX;

	public AudioSource flashLightNoise;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Only if you've aqcuired the flashlight
		if(hasFlashlight){
			if(CrossPlatformInputManager.GetButtonDown("FlashlightOn")){
				ChangeFlashlightState();
			}
		}
	}

	public void DeleteFlashlight() {
		Destroy(flashLight);
		GrowArms();
	}

	void GrowArms(){
		arms.SetActive(true);
		flashLightOn = true;
	}

	void ChangeFlashlightState(){

		if(flashLightOn){
			flashLightNoise.clip = flashLightOffSFX;
			flashLightNoise.Play();
			flashLightOn = false;
			flashlightSource.enabled = false;
		}else{
			flashLightNoise.clip = flashLightOnSFX;
			flashLightNoise.Play();
			flashLightOn = true;
			flashlightSource.enabled = true;
		}
		
	}


}

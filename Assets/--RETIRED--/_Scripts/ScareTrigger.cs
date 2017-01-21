using UnityEngine;
using System.Collections;

public class ScareTrigger : MonoBehaviour {

	//Reference to the trigger that's being activated so it can be deleted after entering
	public GameObject thisTrigger;

	//An array of doors that will either open or shut
	public Door [] doors;

	//An array of lights to either turn on or off
	public Light [] lights;

	//Array of all the breathing noises
	public AudioClip [] breathing;

	public AudioClip jumpScareSFX1;

	public AudioSource jumpScareSound;

	public AudioSource breathGenerator;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			CheckScareEvents();
			Destroy(thisTrigger);

		}
	}

	void CheckScareEvents(){
		JumpScareSound();
		DoorScare();
		LightScare();
	}

	//Deals with scare events involving doors
	void DoorScare(){
		//Loop through every door in the array
		foreach(Door door in doors){
			if(door.GetComponent<Door>().open == false){
				door.ChangeDoorState();
			}else{
				door.ChangeDoorState();
			}
		}
	}

	//Deals with scare events involving lights
	void LightScare(){
		//Loop through every door in the array
		foreach(Light light in lights){
			if(light.isActiveAndEnabled){
				light.enabled = false;
			}else{
				light.enabled = true;
			}
		}
	}

	void JumpScareSound(){
		jumpScareSound.clip = jumpScareSFX1;
		jumpScareSound.Play();
		BreathLoudly();

	}

	void BreathLoudly(){
		int randomBreath = Random.Range(0,breathing.Length);

		breathGenerator.clip = breathing[randomBreath];
		breathGenerator.PlayDelayed(2f);


	}


}

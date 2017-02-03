using UnityEngine;
using System.Collections;

public class ScareTrigger : MonoBehaviour {

	//Reference to the trigger that's being activated so it can be deleted after entering
	public GameObject thisTrigger;

	//An array of doors that will either open or shut
	public Door [] doors;

	//An array of lights to either turn on or off
	public Light [] lights;

	public GameObject objectToMove1;
	public GameObject objectToMove2;

	public Vector3 object1NewPosition;
	public Vector3 object2NewPosition;

	public Quaternion object1NewRotation;
	public Quaternion object2NewRotation;

	//Array of all the breathing noises
	public AudioClip [] breathing;

	public AudioClip jumpScareSFX1;

	public AudioSource jumpScareSound;

	public AudioSource breathGenerator;

	public bool isLerp = false;

	public float lerpSpeed;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			CheckScareEvents();
			if(!isLerp){
				Destroy(thisTrigger);
			}
		}
	}

	void CheckScareEvents(){
		JumpScareSound();
		DoorScare();
		LightScare();
		MoveObjects();
		StartCoroutine(LerpObjects());
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

	void MoveObjects(){
		if(!isLerp){
			if(objectToMove1){
				objectToMove1.transform.position = object1NewPosition;
				objectToMove1.transform.rotation = object1NewRotation;
			}else{
				return;
			}

			if(objectToMove2){
				objectToMove2.transform.position = object2NewPosition;
				objectToMove2.transform.rotation = object2NewRotation;
			}else{
				return;
			}
		}
	}

	IEnumerator LerpObjects(){

		while(isLerp){
			float step = lerpSpeed * Time.deltaTime;
			objectToMove1.transform.position = Vector3.Lerp(objectToMove1.transform.position, object1NewPosition, step);

			if(objectToMove1.transform.position == object1NewPosition){
				Destroy(thisTrigger);
				yield break;

			}

			yield return null;
		}
	}

}

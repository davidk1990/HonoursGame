using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	//Audioclips for the doors opening and shutting
	//May want to change these
	public AudioClip doorOpen;
	public AudioClip doorShut;
	public AudioClip lockedDoor;
	public AudioClip [] psychoSFX;

	//Is the door open
	public bool open = false;

	//Is the door jammed
	public bool jammed = false;

	//Is the door locked
	public bool locked = false;

	//if the door is supposed to be ajar
	public bool doorAjar;

	//Angles for door being open and shut
	public float doorOpenAngle = -90f;
	public float doorCloseAngle = 0f;


	//Speed the door opens at
	private float smooth = 2f;

	AudioSource doorSound;

	// Use this for initialization
	void Start () {
		doorSound = GetComponent<AudioSource>();
	}

	//Accessible from other scripts to change state of door
	public void ChangeDoorState(){
		//If the door isn't jammed or locked
		if(!jammed && !locked){
			
			//If it's open then shut it and vice versa
			open = !open;

			if(open){
				doorSound.clip = doorOpen;
				doorSound.Play();
			}else{
				doorSound.clip = doorShut;
				doorSound.PlayDelayed(1.2f);
			}
		}else{//If the door is locked
			doorSound.clip = lockedDoor;
			doorSound.Play();
			//Play the psycho noise after determined time
			if(jammed){
				Invoke("PlayPsychoNoise", 0.5f);
			}

		}

	}
	
	// Update is called once per frame
	void Update () {

	if(!doorAjar){

		if(open){//open == true
			Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
		}else{
			Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
		}
	}

	}

	void PlayPsychoNoise(){
		int randomSFX = Random.Range(0,psychoSFX.Length);

		doorSound.clip = psychoSFX[randomSFX];
		doorSound.Play();
	}
}

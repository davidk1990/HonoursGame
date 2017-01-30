using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class GroundAudio : MonoBehaviour {

	public List<GroundType> groundTypes = new List<GroundType>();
	public FirstPersonController FPC;
	public string currentGround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.transform.tag == "Snow"){
			SetGroundType(groundTypes[1]);
		}else{
			SetGroundType(groundTypes[0]);
		}
	}

	public void SetGroundType(GroundType ground){
		if(currentGround != ground.name){
			FPC.m_FootstepSounds = ground.footstepSounds;
			FPC.m_WalkSpeed = ground.walkSpeed;
			FPC.m_RunSpeed = ground.runSpeed;
			currentGround = ground.name;
		}
	}
}

[System.Serializable]
public class GroundType
{
	public string name;
	public AudioClip[] footstepSounds;
	public float walkSpeed;
	public float runSpeed;
}
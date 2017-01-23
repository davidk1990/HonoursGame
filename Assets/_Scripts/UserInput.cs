using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class UserInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckUserInput();
	}

	void CheckUserInput(){
		if(Input.anyKeyDown){
			//Debug.Log("Pressing any buttong");
		}
	}
}

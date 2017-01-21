using UnityEngine;
using System.Collections;

public class CCTVCamera : MonoBehaviour {

	public Camera cctv;

	//Y rotation for the cameras
	public float startY;
	public float endY;

	public bool rotate = false;

	public float smooth = 0.2f;

	//Counts how long the camera has been rotating
	public float rotateTime = 0.0f;

	//Change these to change the length of time the camera rotates
	public float rotateTime1;
	public float rotateTime2;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Quaternion startRotation = Quaternion.Euler(0, startY,0);
		Quaternion endRotation = Quaternion.Euler(0, endY,0);

		//Quaternion currentRotation = startRotation;	

		rotateTime += Time.deltaTime;

		if(rotateTime <= rotateTime1){
			transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, smooth * Time.deltaTime);

		}else if(rotateTime >rotateTime1 && rotateTime <=rotateTime2){
			transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, smooth * Time.deltaTime);
		}else if(rotateTime >= rotateTime2){
			rotateTime = 0;
		}

//		if(currentRotation == startRotation){
//			
//			currentRotation = endRotation;
//		}else{
//			
//			currentRotation = startRotation;
//		}

		
	}



}

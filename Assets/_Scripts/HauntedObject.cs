using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedObject : MonoBehaviour {

	public GameObject hauntedObject;

	public Vector3 hauntedObjectNewPos;

	public float lerpSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveEvents(){
		StartCoroutine(MoveHauntedObject());
	}

	public IEnumerator MoveHauntedObject(){

		while(hauntedObject.transform.position != hauntedObjectNewPos){
			float step = lerpSpeed * Time.deltaTime;
			hauntedObject.transform.position = Vector3.Lerp(hauntedObject.transform.position, hauntedObjectNewPos, step);

			if(hauntedObject.transform.position == hauntedObjectNewPos){
				yield break;

			}

			yield return null;
		}
	}
}

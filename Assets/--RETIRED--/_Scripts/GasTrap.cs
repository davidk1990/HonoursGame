using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GasTrap : MonoBehaviour {

	//Value for the current breath level
	public float currentBreath;

	//Value for maximum breath amount
	public float maxBreath = 100.0f;

	//Value for minimum breath amount
	public float minBreath = 0.0f;

	//Value for loss of breath amount
	public float breathLoss = 5.0f;

	public VignetteAndChromaticAberration VCA;

	// Use this for initialization
	void Start () {
		currentBreath = maxBreath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider collider){
		if(collider.tag == "Player"){
			GasDamage();

		}
	}

	void GasDamage(){
		if(currentBreath > minBreath){
			currentBreath -= breathLoss * Time.deltaTime;
			VCA.intensity += 0.008f;

		}

		if(currentBreath <= minBreath){
			Debug.Log("You died");
		}
	}
}

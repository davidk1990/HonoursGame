using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

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

	public GameObject gasGenerator;

	public GameObject doorToClose;

	public AudioSource chokingSFX;

	// Use this for initialization
	void Start () {
		currentBreath = maxBreath;
	}
	
	// Update is called once per frame
	void Update () {
		if(VCA.enabled){
			//VCA.blur += 0.1f;
			VCA.chromaticAberration += 0.01f;
			VCA.intensity += 0.01f;
		}

	}

	void OnTriggerStay(Collider collider){
		if(collider.tag == "Player"){
			GasDamage();
		}
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			//GasDamage();

			gasGenerator.SetActive(true);
			VCA.enabled = true;
			doorToClose.GetComponent<Door>().ChangeDoorState();
			doorToClose.GetComponent<Door>().locked = true;
			chokingSFX.Play();
		}
	}

	void GasDamage(){
		if(currentBreath > minBreath){
			currentBreath -= breathLoss * Time.deltaTime;
			VCA.intensity += 0.008f;
		}

		if(currentBreath <= minBreath){
			SceneManager.LoadScene(1);
		}
	}


}

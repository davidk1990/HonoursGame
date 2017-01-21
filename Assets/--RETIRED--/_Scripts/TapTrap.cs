using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class TapTrap : MonoBehaviour {

	//Current value of the meter
	public float currentValue;

	//Value that the meter will start at
	public float startValue = 50.0f;

	//Value for meter to be empty 
	public float emptyValue = 0.0f;

	//Value for the meter to be full
	public float fullValue = 100.0f;

	//Empty rate
	public float emptyRate = 5f;

	//Fill rate
	public float fillRate = 1.0f;

	//Access to the slider
	public Slider tapSlider;


	// Use this for initialization
	void Start () {
		currentValue = startValue;
		tapSlider.minValue = emptyValue;
		tapSlider.maxValue = fullValue;
		tapSlider.value = currentValue;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentValue > emptyValue){
			currentValue -= emptyRate * Time.deltaTime;

		}

		if(currentValue <= emptyValue){
			Debug.Log("You died");
		}else if(currentValue >= fullValue){
			Debug.Log("You win");
		}

		if(CrossPlatformInputManager.GetButtonDown("ControllerInteract")){
			Debug.Log("Pressing interact button");
			currentValue += fillRate;
		}

		tapSlider.value = currentValue;
	}
}
